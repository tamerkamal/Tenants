using Amazon.APIGateway.Model;
using Amazon.CognitoIdentityProvider.Model;
using Base.Helpers.Mapper;
using Base.Infrastructure.BaseRepository;
using Base.Infrastructure.UnitOfWork;
using Master.DTO;
using Master.Entity.Models;
using Master.Service.AWS.APIGateway.Interfaces;
using Master.Service.AWS.Cognito.Interfaces;
using Master.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AWS.Service.APIGateway.Models;
using Microsoft.Extensions.Options;
using Master.Repository.Classes;

namespace Master.Service.CLasses
{
    public class TenantService : ITenantService
    {
        #region Fields 

        public readonly IUnitOfWork _unitOfWork;

        public readonly IUserPoolService _userPoolService;
        public readonly IAPIGatewayService _aPIGatewayService;

        private readonly AwsApiGatewaySettings _gatewaySettings;

        #endregion

        #region Constructor

        public TenantService(IUnitOfWork unitOfWork,
                             IOptionsSnapshot<AwsApiGatewaySettings> gatewaySettings,
                             IUserPoolService userPoolService,
                             IAPIGatewayService aPIGatewayService)
        {
            _unitOfWork = unitOfWork;
            _gatewaySettings = gatewaySettings.Value;
            _userPoolService = userPoolService;
            _aPIGatewayService = aPIGatewayService;
        }

        #region Dispose

        public void Dispose()
        {
            _unitOfWork?.Dispose();
            _aPIGatewayService?.Dispose();
            _userPoolService?.Dispose();
        }

        #endregion

        #region Main Methods

        public async Task<CreateTenantResDTO> CreateTenant(CreateTenantReqDTO createTenantReqDTO)
        {
            var createTenantResDTO = new CreateTenantResDTO();

            var createUserPoolResponse = new CreateUserPoolResponse();
            var createUserPoolClientResponse = new CreateUserPoolClientResponse();
            var createGroupResponse = new CreateGroupResponse();
            var adminCreateUserResponse = new AdminCreateUserResponse();
            var adminAddUserToGroupResponse = new AdminAddUserToGroupResponse();
            var updateAuthorizerResponseList = new List<UpdateAuthorizerResponse>();

            string responseMessage = string.Empty;

            Exception exception = null;

            try
            {
                #region AWS Server Operations


                #region 1: Create 'Pool' of Users

                createUserPoolResponse = await _userPoolService.CreateUserPoolAsync(new CreateUserPoolRequest
                {
                    PoolName = createTenantReqDTO.SubDomain + "_Pool",
                    //...........
                });


                if (createUserPoolResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(CreateTenantResDTO.CreateUserPoolFailed);
                }

                createTenantResDTO.IsCreateUserPoolSucceeded = true;

                #endregion

                #region 2: Create 'CLient' for Pool 

                createUserPoolClientResponse = await _userPoolService.CreateUserPoolClientAsync(new CreateUserPoolClientRequest
                {
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    //.........
                });

                if (createUserPoolClientResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(CreateTenantResDTO.CreateUserPoolClientFailed);
                }

                createTenantResDTO.IsCreatUserPoolClientSucceeded = true;

                #endregion

                #region 3: Create Pool 'Group'

                createGroupResponse = await _userPoolService.CreateGroupAsync(new CreateGroupRequest
                {
                    GroupName = "Admins",
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    //.........
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(CreateTenantResDTO.CreateUserPoolGroupFailed);
                }

                createTenantResDTO.IsCreatedUserPoolGroupSucceeded = true;

                #endregion

                #region 4: Add 'new User' to created Pool

                adminCreateUserResponse = await _userPoolService.AdminCreateUserAsync(new AdminCreateUserRequest
                {
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    Username = createTenantReqDTO.SubDomain + "_Username",
                    //UserAttributes = new List<AttributeType> { new AttributeType { Name = "...", Value = "..." } },
                    //...................
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(CreateTenantResDTO.CreateUserFailed);
                }

                createTenantResDTO.IsCreatedUserSucceeded = true;

                #endregion

                #region 5: Add 'User To Group' 

                adminAddUserToGroupResponse = await _userPoolService.AdminAddUserToGroupAsync(new AdminAddUserToGroupRequest
                {
                    GroupName = "Admins",
                    Username = adminCreateUserResponse.User.Username,
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(CreateTenantResDTO.AddUserToGroupFailed);
                }

                createTenantResDTO.IsAddUserToGroupSucceeded = true;

                #endregion

                #region 6: Update APIGateway Authorizers Arns

                updateAuthorizerResponseList = await UpdateAPIGatewayAuthorizersArns(createUserPoolResponse.UserPool.Arn);

                if (updateAuthorizerResponseList?.Any(m => m.HttpStatusCode != System.Net.HttpStatusCode.OK) == true)
                {
                    throw new Exception(CreateTenantResDTO.UpdatedAuthorizersFailed);
                }

                createTenantResDTO.IsUpdatedAuthorizersSucceeded = true;

                #endregion


                #endregion

                #region MSSQL Server Operations


                #region 7: Create Tenant Database

                var tenantRepository = _unitOfWork.GetRepository<TenantRepository>();

                try
                {
                    
                    await tenantRepository.CreateTenantDatabaseClone($"{createTenantReqDTO.SubDomain}_database");

                    createTenantResDTO.IsCreateTenantDatabaseSucceeded = true;
                }
                catch
                {
                    throw new Exception(CreateTenantResDTO.CreateTenantDatabaseFailed);
                }

                #endregion

                #region 8: Create Subscription

                try
                {
                 createTenantResDTO.SubscriptionId =  await CreateSubscription(new CreateSubscriptionReqDTO
                    {
                        TierId = createTenantReqDTO.TierId,
                        SubscriptionId = createTenantReqDTO.SubscriptionId,
                        CreatedBy = createTenantReqDTO.SubDomain,
                        CreatedOn = DateTime.Now,
                        ExpiresOn = DateTime.Now.AddYears(1)
                    });

                    createTenantResDTO.IsCreateSubscriptionSucceeded = true;
                }
                catch
                {
                    
                  await  tenantRepository.DropDatabaseClone($"{createTenantReqDTO.SubDomain}_database");
                }

                #endregion

                #region 9: Create Tenant

                try
                {
                    await CreateTenantEntity(createTenantReqDTO);

                    createTenantResDTO.IsCreateTenantSucceeded = true;
                }
                catch
                {
                    var subscriptionRepository = _unitOfWork.GetRepository<BaseRepository<Subscription>>();

                    await subscriptionRepository.DeleteAsync(createTenantResDTO.SubscriptionId);

                    // ToDo Drop Database
                }

                #endregion


                #endregion
            }

            catch (Exception ex)
            {
                exception = ex;

                if (!createTenantResDTO.IsCreateUserPoolSucceeded)
                {
                    // Nothing to do because nothing was created 
                }
                else if (!createTenantResDTO.IsCreatUserPoolClientSucceeded)
                {
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);
                }
                else if (!createTenantResDTO.IsCreatedUserPoolGroupSucceeded)
                {
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);
                }
                else if (!createTenantResDTO.IsCreatedUserSucceeded)
                {
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);
                }
                else if (!createTenantResDTO.IsAddUserToGroupSucceeded)
                {
                    await UndoAdminCreateUserAsync(createUserPoolResponse.UserPool.Id, adminCreateUserResponse.User.Username);
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);
                }
                else if (!createTenantResDTO.IsUpdatedAuthorizersSucceeded)
                {
                    await UndoAdminAddUserToGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName, adminCreateUserResponse.User.Username);
                    await UndoAdminCreateUserAsync(createUserPoolResponse.UserPool.Id, adminCreateUserResponse.User.Username);
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);
                }
                else if (!createTenantResDTO.IsCreateTenantDatabaseSucceeded)
                {
                    await UndoAdminAddUserToGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName, adminCreateUserResponse.User.Username);
                    await UndoAdminCreateUserAsync(createUserPoolResponse.UserPool.Id, adminCreateUserResponse.User.Username);
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);

                    throw ex;
                }
                else if (!createTenantResDTO.IsCreateSubscriptionSucceeded)
                {
                    await UndoAdminAddUserToGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName, adminCreateUserResponse.User.Username);
                    await UndoAdminCreateUserAsync(createUserPoolResponse.UserPool.Id, adminCreateUserResponse.User.Username);
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);

                    throw ex;
                }
                else if (!createTenantResDTO.IsCreateTenantSucceeded)
                {
                    await UndoAdminAddUserToGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName, adminCreateUserResponse.User.Username);
                    await UndoAdminCreateUserAsync(createUserPoolResponse.UserPool.Id, adminCreateUserResponse.User.Username);
                    await UndoCreateGroupAsync(createUserPoolResponse.UserPool.Id, createGroupResponse.Group.GroupName);
                    await UndoCreateUserPoolClientAsync(createUserPoolResponse.UserPool.Id, createUserPoolClientResponse.UserPoolClient.ClientId);
                    await UndoCreateUserPoolAsync(createUserPoolResponse.UserPool.Id);

                    throw ex;
                }
            }

            finally
            {
                if (exception != null)
                {
                    createTenantResDTO.ResponseMessage = "Subscription failed!,please try again";
                }
            }

            return createTenantResDTO;
        }

        #endregion

        #region Helper Methods

        #region Do Operations

        /// <summary>
        /// https://dev.to/biglucas/using-the-api-gateway-authorizer-with-multi-user-pools-20k1
        /// </summary>       
        private async Task<List<UpdateAuthorizerResponse>> UpdateAPIGatewayAuthorizersArns(string newPoolArn)
        {
            // 6: Get APIGateway 'Authorizers' 
            GetAuthorizersResponse getAuthorizersResponse = await _aPIGatewayService.GetAuthorizersAsync(new GetAuthorizersRequest
            {
                RestApiId = _gatewaySettings.ID, // ID of the API Gateway
            });

            var allUserPoolsArnList = await GetAllUserPoolsArnList();

            allUserPoolsArnList.Add(newPoolArn);

            // 7: Add Pool to APIGateway 'Authorizers'

            List<UpdateAuthorizerResponse> updateAuthorizerResponseList = new List<UpdateAuthorizerResponse>();

            foreach (Authorizer authorizer in getAuthorizersResponse?.Items)
            {
                var updateAuthorizerRequest = new UpdateAuthorizerRequest
                {
                    AuthorizerId = authorizer.Id,
                    RestApiId = _gatewaySettings.ID,
                };

                foreach (var arn in allUserPoolsArnList)
                {
                    updateAuthorizerRequest.PatchOperations.Add(new PatchOperation
                    { Path = "/providerARNs", Value = arn });
                }

                updateAuthorizerResponseList.Add(await _aPIGatewayService.UpdateAuthorizerAsync(updateAuthorizerRequest));
            }

            return updateAuthorizerResponseList;
        }

        private async Task<List<string>> GetAllUserPoolsArnList()
        {
            // Declare Repositories            
            var tenantRepository = _unitOfWork.GetRepository<BaseRepository<Tenant>>();

            List<string> userPoolsArnList = await tenantRepository.TableNoTracking.Select(m => m.CognitoPoolArn).ToListAsync();

            return userPoolsArnList;
        }


        private async Task<int> CreateSubscription(CreateSubscriptionReqDTO model)
        {
            var subscriptionRepository = _unitOfWork.GetRepository<BaseRepository<Subscription>>();

            var subscription = new Subscription();

            Mapper.Instance.Map<CreateSubscriptionReqDTO, Subscription>(model, subscription);

            Subscription result = await subscriptionRepository.InsertAsync(subscription);

            return result.SubscriptionId;
        }

        private async Task<int> CreateTenantEntity(CreateTenantReqDTO model)
        {
            var tenantRepository = _unitOfWork.GetRepository<BaseRepository<Tenant>>();

            var tenant = new Tenant();

            Mapper.Instance.Map<CreateTenantReqDTO, Tenant>(model, tenant);

            Tenant result = await tenantRepository.InsertAsync(tenant);

            return result.TenantId;
        }

        #endregion

        #region Undo Operations 

        private async Task<DeleteUserPoolResponse> UndoCreateUserPoolAsync(string userPoolId)
        {
            DeleteUserPoolResponse deleteUserPoolResponse = await _userPoolService.DeleteUserPoolAsync(new DeleteUserPoolRequest
            {
                UserPoolId = userPoolId
            });

            return deleteUserPoolResponse;
        }

        private async Task<DeleteUserPoolClientResponse> UndoCreateUserPoolClientAsync(string userPoolId, string clientId)
        {
            DeleteUserPoolClientResponse deleteUserPoolClientResponse = await _userPoolService.DeleteUserPoolClientAsync(new DeleteUserPoolClientRequest
            {
                UserPoolId = userPoolId,
                ClientId = clientId
            });

            return deleteUserPoolClientResponse;
        }

        private async Task<DeleteGroupResponse> UndoCreateGroupAsync(string userPoolId, string groupName)
        {
            DeleteGroupResponse deleteGroupResponse = await _userPoolService.DeleteGroupAsync(new DeleteGroupRequest
            {
                UserPoolId = userPoolId,
                GroupName = groupName
            });

            return deleteGroupResponse;
        }

        private async Task<AdminDeleteUserResponse> UndoAdminCreateUserAsync(string userPoolId, string username)
        {
            AdminDeleteUserResponse deleteGroupResponse = await _userPoolService.AdminDeleteUserAsync(new AdminDeleteUserRequest
            {
                UserPoolId = userPoolId,
                Username = username
            });

            return deleteGroupResponse;
        }

        private async Task<AdminRemoveUserFromGroupResponse> UndoAdminAddUserToGroupAsync(string userPoolId, string groupName, string username)
        {
            AdminRemoveUserFromGroupResponse adminRemoveUserFromGroupResponse = await _userPoolService.AdminRemoveUserFromGroupAsync(new AdminRemoveUserFromGroupRequest
            {
                GroupName = groupName,
                UserPoolId = userPoolId,
                Username = username
            });

            return adminRemoveUserFromGroupResponse;
        }

        private async Task<List<UpdateAuthorizerResponse>> UndoUpdateAPIGatewayAuthorizersArns(string newPoolArn)
        {
            GetAuthorizersResponse getAuthorizersResponse = await _aPIGatewayService.GetAuthorizersAsync(new GetAuthorizersRequest
            {
                RestApiId = _gatewaySettings.ID, // ID of the API Gateway
            });

            var allUserPoolsArnList = await GetAllUserPoolsArnList();

            // Remove Pool from APIGateway 'Authorizers'

            List<UpdateAuthorizerResponse> undoUpdateAuthorizerArnsResponseList = new List<UpdateAuthorizerResponse>();

            foreach (Authorizer authorizer in getAuthorizersResponse?.Items)
            {
                var updateAuthorizerRequest = new UpdateAuthorizerRequest
                {
                    AuthorizerId = authorizer.Id,
                    RestApiId = _gatewaySettings.ID,
                };

                foreach (var arn in allUserPoolsArnList)
                {
                    updateAuthorizerRequest.PatchOperations.Add(new PatchOperation
                    { Path = "/providerARNs", Value = arn });

                    updateAuthorizerRequest.PatchOperations.Remove(new PatchOperation
                    { Path = "/providerARNs", Value = newPoolArn });
                }

                undoUpdateAuthorizerArnsResponseList.Add(await _aPIGatewayService.UpdateAuthorizerAsync(updateAuthorizerRequest));
            }

            return undoUpdateAuthorizerArnsResponseList;
        }

        #endregion

        #endregion

        #endregion
    }
}
