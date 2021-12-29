using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Threading.Tasks;
using Tenants.Service.AWS.Cognito.Interfaces;

namespace Tenants.Service.AWS.Cognito.CLasses
{
    public class UserPoolService : IUserPoolService
    {
        #region Fields

        private readonly IAmazonCognitoIdentityProvider _cognitoIdentityProvider;

        #endregion

        #region Constructor

        public UserPoolService(IAmazonCognitoIdentityProvider cognitoIdentityProvider)
        {
            _cognitoIdentityProvider = cognitoIdentityProvider;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _cognitoIdentityProvider.Dispose();
        }

        #endregion

        #region Main Methods

        #region UserPools Operations

        public async Task<CreateUserPoolResponse> CreateUserPoolAsync(CreateUserPoolRequest request)
        {
            CreateUserPoolResponse response = await _cognitoIdentityProvider.CreateUserPoolAsync(request);

            return response;
        }

        public async Task<UpdateUserPoolResponse> UpdateUserPoolAsync(UpdateUserPoolRequest request)
        {
            UpdateUserPoolResponse response = await _cognitoIdentityProvider.UpdateUserPoolAsync(request);

            return response;
        }

        public async Task<DeleteUserPoolResponse> DeleteUserPoolAsync(DeleteUserPoolRequest request)
        {
            DeleteUserPoolResponse response = await _cognitoIdentityProvider.DeleteUserPoolAsync(request);

            return response;
        }

        public async Task<AddCustomAttributesResponse> AddCustomAttributesAsync(AddCustomAttributesRequest request)
        {
            AddCustomAttributesResponse response = await _cognitoIdentityProvider.AddCustomAttributesAsync(request);
            return response;
        }

        #endregion

        #region Users Operations

        public async Task<AdminCreateUserResponse> AdminCreateUserAsync(AdminCreateUserRequest request)
        {
            AdminCreateUserResponse response = await _cognitoIdentityProvider.AdminCreateUserAsync(request);

            return response;
        }

        public async Task<AdminGetUserResponse> AdminGetUserAsync(AdminGetUserRequest request)
        {
            AdminGetUserResponse response = await _cognitoIdentityProvider.AdminGetUserAsync(request);

            return response;
        }

        public async Task<AdminDeleteUserResponse> AdminDeleteUserAsync(AdminDeleteUserRequest request)
        {
            AdminDeleteUserResponse response = await _cognitoIdentityProvider.AdminDeleteUserAsync(request);

            return response;
        }
        
        public async Task<AdminSetUserPasswordResponse> AdminSetUserPasswordAsync(AdminSetUserPasswordRequest request)
        {
            AdminSetUserPasswordResponse response = await _cognitoIdentityProvider.AdminSetUserPasswordAsync(request);

            return response;
        }        
        public async Task<AdminResetUserPasswordResponse> AdminResetUserPasswordAsync(AdminResetUserPasswordRequest request)
        {
            AdminResetUserPasswordResponse response = await _cognitoIdentityProvider.AdminResetUserPasswordAsync(request);

            return response;
        }   
        public async Task<AdminSetUserMFAPreferenceResponse> AdminSetUserMFAPreferenceAsync(AdminSetUserMFAPreferenceRequest request)
        {
            AdminSetUserMFAPreferenceResponse response = await _cognitoIdentityProvider.AdminSetUserMFAPreferenceAsync(request);

            return response;
        }
          public async Task<SetUserMFAPreferenceResponse> SetUserMFAPreferenceAsync(SetUserMFAPreferenceRequest request)
        {
            SetUserMFAPreferenceResponse response = await _cognitoIdentityProvider.SetUserMFAPreferenceAsync(request);

            return response;
        }

        #endregion

        #region User Attributes Operations

        public async Task<AdminUpdateUserAttributesResponse> AdminUpdateUserAttributesAsync(AdminUpdateUserAttributesRequest request)
        {
            AdminUpdateUserAttributesResponse response = await _cognitoIdentityProvider.AdminUpdateUserAttributesAsync(request);

            return response;
        }

        public async Task<AdminDeleteUserAttributesResponse> AdminDeleteUserAttributesAsync(AdminDeleteUserAttributesRequest request)
        {
            AdminDeleteUserAttributesResponse response = await _cognitoIdentityProvider.AdminDeleteUserAttributesAsync(request);
            return response;
        }   
        public async Task<AdminDisableUserResponse> AdminDisableUserAsync(AdminDisableUserRequest request)
        {
            AdminDisableUserResponse response = await _cognitoIdentityProvider.AdminDisableUserAsync(request);
            return response;
        }
        public async Task<AdminEnableUserResponse> AdminEnableUserAsync(AdminEnableUserRequest request)
        {
            AdminEnableUserResponse response = await _cognitoIdentityProvider.AdminEnableUserAsync(request);
            return response;
        }

        #endregion

        #region Groups Operations

        public async Task<CreateGroupResponse> CreateGroupAsync(CreateGroupRequest request)
        {
            CreateGroupResponse response = await _cognitoIdentityProvider.CreateGroupAsync(request);

            return response;
        }
        public async Task<GetGroupResponse> GetGroupAsync(GetGroupRequest request)
        {
            GetGroupResponse response = await _cognitoIdentityProvider.GetGroupAsync(request);

            return response;
        }

        public async Task<ListGroupsResponse> ListGroupsAsync(ListGroupsRequest request)
        {
            ListGroupsResponse response = await _cognitoIdentityProvider.ListGroupsAsync(request);

            return response;
        }

        public async Task<UpdateGroupResponse> UpdateGroupAsync(UpdateGroupRequest request)
        {
            UpdateGroupResponse response = await _cognitoIdentityProvider.UpdateGroupAsync(request);

            return response;
        }

        public async Task<DeleteGroupResponse> DeleteGroupAsync(DeleteGroupRequest request)
        {
            DeleteGroupResponse response = await _cognitoIdentityProvider.DeleteGroupAsync(request);

            return response;
        }

        #endregion

        #region UserGroups Opertions

        public async Task<AdminAddUserToGroupResponse> AdminAddUserToGroupAsync(AdminAddUserToGroupRequest request)
        {
            AdminAddUserToGroupResponse response = await _cognitoIdentityProvider.AdminAddUserToGroupAsync(request);

            return response;
        }

        public async Task<AdminListGroupsForUserResponse> AdminListGroupsForUserAsync(AdminListGroupsForUserRequest request)
        {
            AdminListGroupsForUserResponse response = await _cognitoIdentityProvider.AdminListGroupsForUserAsync(request);

            return response;
        }

        public async Task<AdminRemoveUserFromGroupResponse> AdminRemoveUserFromGroupAsync(AdminRemoveUserFromGroupRequest request)
        {
            AdminRemoveUserFromGroupResponse response = await _cognitoIdentityProvider.AdminRemoveUserFromGroupAsync(request);

            return response;
        }

        #endregion

        #endregion
    }
}