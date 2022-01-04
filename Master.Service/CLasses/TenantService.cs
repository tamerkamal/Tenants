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

namespace Master.Service.CLasses
{
    public class TenantService : ITenantService
    {
        #region Fields 

        public readonly IUnitOfWork _unitOfWork;

        public readonly IUserPoolService _userPoolService;
        public readonly IAPIGatewayService _aPIGatewayService;

        #endregion

        #region Constructor

        public TenantService(IUnitOfWork unitOfWork, IUserPoolService userPoolService, IAPIGatewayService aPIGatewayService)
        {
            _unitOfWork = unitOfWork;
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
            // Declare Repositories            
            var tenantRepository = _unitOfWork.GetRepository<BaseRepository<Tenant>>();

            var createTenantResDTO = new CreateTenantResDTO();

            try
            {
                // 1: Create 'Pool' of Users
                CreateUserPoolResponse createUserPoolResponse = await _userPoolService.CreateUserPoolAsync(new CreateUserPoolRequest
                {
                    PoolName = createTenantReqDTO.SubDomain + "_Pool",
                    //...........
                });

                if (createUserPoolResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Creation of Pool failed!");
                }

                // 2: Create 'CLient' for Pool 
                CreateUserPoolClientResponse createUserPoolClientResponse = await _userPoolService.CreateUserPoolClientAsync(new CreateUserPoolClientRequest
                {
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    //.........
                });

                if (createUserPoolClientResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Creation of Client failed!");
                }

                // 3: Create Pool 'Group'
                CreateGroupResponse createGroupResponse = await _userPoolService.CreateGroupAsync(new CreateGroupRequest
                {
                    GroupName = "Admins",
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    //.........
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Creation of Group failed!");
                }

                // 4: Add 'new User' to created Pool
                AdminCreateUserResponse adminCreateUserResponse = await _userPoolService.AdminCreateUserAsync(new AdminCreateUserRequest
                {
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                    Username = createTenantReqDTO.SubDomain + "_Username",
                    UserAttributes = new List<AttributeType> { new AttributeType { Name = "...", Value = "..." } },
                    //...................
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Creation of User failed!");
                }

                // 5: Add 'User To Group' 
                AdminAddUserToGroupResponse adminAddUserToGroupResponse = await _userPoolService.AdminAddUserToGroupAsync(new AdminAddUserToGroupRequest
                {
                    GroupName = "Admins",
                    Username = adminCreateUserResponse.User.Username,
                    UserPoolId = createUserPoolResponse.UserPool.Id,
                });

                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Adding User To Group failed!");
                }

                // 6: Get APIGateway 'Authorizers' 
                GetAuthorizersResponse getAuthorizersResponse = await _aPIGatewayService.GetAuthorizersAsync(new GetAuthorizersRequest
                {
                    RestApiId = "vjhzvxumkd", // ID of the Gateway called MyApi
                });

                // 7: Add Pool to APIGateway 'Authorizers' 
                // https://dev.to/biglucas/using-the-api-gateway-authorizer-with-multi-user-pools-20k1

                foreach (var authorizer in getAuthorizersResponse?.Items)
                {
                    authorizer.ProviderARNs.Add(createUserPoolResponse.UserPool.Arn);

                    UpdateAuthorizerResponse updateAuthorizerResponse = await _aPIGatewayService.UpdateAuthorizerAsync(new UpdateAuthorizerRequest
                    {
                      AuthorizerId= authorizer.Id,
                      PatchOperations=new List<PatchOperation>
                      {
                          new PatchOperation {Path="/providerARNs",Value=createUserPoolResponse.UserPool.Arn},
                          new PatchOperation {Path="/providerARNs",Value=createUserPoolResponse.UserPool.Arn},
                      }
                    });
                }



                if (createGroupResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Adding User To Group failed!");
                }

               // vae addUserPoolToAuthorizerResponse = await _aPIGatewayService.UpdateAuthorizerAsync()
            }

            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "":
                        {

                            break;
                        }

                    default:
                        break;
                }
            }

            return createTenantResDTO;
        }

        #endregion

        #region Helper Methods

        //private bool AddUserPoolToAPIGatewayAuthorizers()
        //{
          

        //    return
        //}

        //private List<string> GetAllAccountUserPoolsArnList()
        //{


        //    return
        //}

        #endregion



        #endregion
    }
}
