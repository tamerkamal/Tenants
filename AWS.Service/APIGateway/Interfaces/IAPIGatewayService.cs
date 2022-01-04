using Amazon.APIGateway.Model;
using System;
using System.Threading.Tasks;

namespace Master.Service.AWS.APIGateway.Interfaces
{
    public interface IAPIGatewayService : IDisposable
    {
        Task<CreateApiKeyResponse> CreateApiKeyAsync(CreateApiKeyRequest request);
        Task<CreateAuthorizerResponse> CreateAuthorizerAsync(CreateAuthorizerRequest request);
        Task<CreateBasePathMappingResponse> CreateBasePathMappingAsync(CreateBasePathMappingRequest request);
        Task<CreateDeploymentResponse> CreateDeploymentAsync(CreateDeploymentRequest request);
        Task<CreateDomainNameResponse> CreateDomainNameAsync(CreateDomainNameRequest request);
        Task<CreateModelResponse> CreateModelAsync(CreateModelRequest request);
        Task<DeleteApiKeyResponse> DeleteApiKeyAsync(DeleteApiKeyRequest request);
        Task<DeleteAuthorizerResponse> DeleteAuthorizerAsync(DeleteAuthorizerRequest request);
        Task<DeleteBasePathMappingResponse> DeleteBasePathMappingAsync(DeleteBasePathMappingRequest request);
        Task<DeleteDeploymentResponse> DeleteDeploymentAsync(DeleteDeploymentRequest request);
        Task<DeleteDomainNameResponse> DeleteDomainNameAsync(DeleteDomainNameRequest request);
        Task<DeleteModelResponse> DeleteModelAsync(DeleteModelRequest request);
        Task<GetApiKeyResponse> GetApiKeyAsync(GetApiKeyRequest request);
        Task<GetApiKeysResponse> GetApiKeysAsync(GetApiKeysRequest request);
        Task<GetAuthorizerResponse> GetAuthorizerAsync(GetAuthorizerRequest request);
        Task<GetAuthorizersResponse> GetAuthorizersAsync(GetAuthorizersRequest request);
        Task<GetBasePathMappingResponse> GetBasePathMappingAsync(GetBasePathMappingRequest request);
        Task<GetBasePathMappingsResponse> GetBasePathMappingsAsync(GetBasePathMappingsRequest request);
        Task<GetDeploymentResponse> GetDeploymentAsync(GetDeploymentRequest request);
        Task<GetDeploymentsResponse> GetDeploymentsAsync(GetDeploymentsRequest request);
        Task<GetDomainNameResponse> GetDomainNameAsync(GetDomainNameRequest request);
        Task<GetDomainNamesResponse> GetDomainNamesAsync(GetDomainNamesRequest request);
        Task<GetModelResponse> GetModelAsync(GetModelRequest request);
        Task<GetModelsResponse> GetModelsAsync(GetModelsRequest request);
        Task<UpdateApiKeyResponse> UpdateApiKeyAsync(UpdateApiKeyRequest request);
        Task<UpdateAuthorizerResponse> UpdateAuthorizerAsync(UpdateAuthorizerRequest request);
        Task<UpdateBasePathMappingResponse> UpdateBasePathMappingAsync(UpdateBasePathMappingRequest request);
        Task<UpdateDeploymentResponse> UpdateDeploymentAsync(UpdateDeploymentRequest request);
        Task<UpdateDomainNameResponse> UpdateDomainNameAsync(UpdateDomainNameRequest request);
        Task<UpdateModelResponse> UpdateModelAsync(UpdateModelRequest request);
    }
}
