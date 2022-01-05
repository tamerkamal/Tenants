using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Threading.Tasks;

namespace Master.Service.AWS.Cognito.Interfaces
{
    public interface IUserPoolService:IDisposable
    {
        Task<CreateUserPoolResponse> CreateUserPoolAsync(CreateUserPoolRequest request);
        Task<UpdateUserPoolResponse> UpdateUserPoolAsync(UpdateUserPoolRequest request);
        Task<DeleteUserPoolResponse> DeleteUserPoolAsync(DeleteUserPoolRequest request);
        Task<AddCustomAttributesResponse> AddCustomAttributesAsync(AddCustomAttributesRequest request);
        Task<AdminCreateUserResponse> AdminCreateUserAsync(AdminCreateUserRequest request);
        Task<AdminGetUserResponse> AdminGetUserAsync(AdminGetUserRequest request);
        Task<AdminDeleteUserResponse> AdminDeleteUserAsync(AdminDeleteUserRequest request);
        Task<AdminSetUserPasswordResponse> AdminSetUserPasswordAsync(AdminSetUserPasswordRequest request);
        Task<AdminResetUserPasswordResponse> AdminResetUserPasswordAsync(AdminResetUserPasswordRequest request);
        Task<AdminSetUserMFAPreferenceResponse> AdminSetUserMFAPreferenceAsync(AdminSetUserMFAPreferenceRequest request);
        Task<SetUserMFAPreferenceResponse> SetUserMFAPreferenceAsync(SetUserMFAPreferenceRequest request);
        Task<AdminUpdateUserAttributesResponse> AdminUpdateUserAttributesAsync(AdminUpdateUserAttributesRequest request);
        Task<AdminDeleteUserAttributesResponse> AdminDeleteUserAttributesAsync(AdminDeleteUserAttributesRequest request);
        Task<AdminDisableUserResponse> AdminDisableUserAsync(AdminDisableUserRequest request);
        Task<AdminEnableUserResponse> AdminEnableUserAsync(AdminEnableUserRequest request);
        Task<CreateGroupResponse> CreateGroupAsync(CreateGroupRequest request);
        Task<GetGroupResponse> GetGroupAsync(GetGroupRequest request);
        Task<ListGroupsResponse> ListGroupsAsync(ListGroupsRequest request);
        Task<UpdateGroupResponse> UpdateGroupAsync(UpdateGroupRequest request);
        Task<DeleteGroupResponse> DeleteGroupAsync(DeleteGroupRequest request);
        Task<AdminAddUserToGroupResponse> AdminAddUserToGroupAsync(AdminAddUserToGroupRequest request);
        Task<AdminListGroupsForUserResponse> AdminListGroupsForUserAsync(AdminListGroupsForUserRequest request);
        Task<AdminRemoveUserFromGroupResponse> AdminRemoveUserFromGroupAsync(AdminRemoveUserFromGroupRequest request);
        Task<CreateUserPoolClientResponse> CreateUserPoolClientAsync(CreateUserPoolClientRequest request);
        Task<ListUserPoolClientsResponse> ListUserPoolClientsAsync(ListUserPoolClientsRequest request);
        Task<UpdateUserPoolClientResponse> UpdateUserPoolClientAsync(UpdateUserPoolClientRequest request);
        Task<DeleteUserPoolClientResponse> DeleteUserPoolClientAsync(DeleteUserPoolClientRequest request);
        Task<SignUpResponse> SignUpAsync(SignUpRequest request);
        Task<CreateResourceServerResponse> CreateResourceServerAsync(CreateResourceServerRequest request);
        Task<ListResourceServersResponse> ListResourceServersAsync(ListResourceServersRequest request);
        Task<UpdateResourceServerResponse> UpdateResourceServerAsync(UpdateResourceServerRequest request);
        Task<DeleteResourceServerResponse> DeleteResourceServerAsync(DeleteResourceServerRequest request);
        Task<ListUserPoolsResponse> ListUserPoolsAsync(ListUserPoolsRequest request);
    }
}
