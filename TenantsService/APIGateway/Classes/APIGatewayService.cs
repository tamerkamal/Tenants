using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;
using AWS.Service.APIGateway.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tenants.Service.AWS.APIGateway.Interfaces;

namespace Tenants.Service.AWS.APIGateway.Classes
{
    public class APIGatewayService : IAPIGatewayService
    {
        #region Fields

        public readonly IAmazonAPIGateway _amazonAPIGateway;
        public readonly AwsApiGatewaySettings _settings;

        #endregion

        #region Constructor

        public APIGatewayService(IOptions<AwsApiGatewaySettings> settings)
        {
            // Receive setting from app-settings.json
            _settings = settings.Value;

            // Initialize RegionEndpoint.
            var region = RegionEndpoint.GetBySystemName(_settings.Region);

            // Initialize credentials.
            var credentials = new BasicAWSCredentials(_settings.ID,null);

            _amazonAPIGateway = new AmazonAPIGatewayClient(credentials, region);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _amazonAPIGateway.Dispose();
        }

        #endregion

        #region Main Methods

        #region Auhtorizers Operations

        public async Task<CreateAuthorizerResponse> CreateAuthorizerAsync(CreateAuthorizerRequest request)
        {
            CreateAuthorizerResponse response = await _amazonAPIGateway.CreateAuthorizerAsync(request);

            return response;
        }

        public async Task<GetAuthorizerResponse> GetAuthorizerAsync(GetAuthorizerRequest request)
        {
            GetAuthorizerResponse response = await _amazonAPIGateway.GetAuthorizerAsync(request);

            return response;
        }

        public async Task<GetAuthorizersResponse> GetAuthorizersAsync(GetAuthorizersRequest request)
        {
            GetAuthorizersResponse response = await _amazonAPIGateway.GetAuthorizersAsync(request);

            return response;
        }

        public async Task<UpdateAuthorizerResponse> UpdateAuthorizerAsync(UpdateAuthorizerRequest request)
        {
            UpdateAuthorizerResponse response = await _amazonAPIGateway.UpdateAuthorizerAsync(request);

            return response;
        }

        public async Task<DeleteAuthorizerResponse> DeleteAuthorizerAsync(DeleteAuthorizerRequest request)
        {
            DeleteAuthorizerResponse response = await _amazonAPIGateway.DeleteAuthorizerAsync(request);

            return response;
        }

        #endregion

        #region ApiKeys Operations

        public async Task<CreateApiKeyResponse> CreateApiKeyAsync(CreateApiKeyRequest request)
        {
            CreateApiKeyResponse response = await _amazonAPIGateway.CreateApiKeyAsync(request);

            return response;
        }

        public async Task<GetApiKeyResponse> GetApiKeyAsync(GetApiKeyRequest request)
        {
            GetApiKeyResponse response = await _amazonAPIGateway.GetApiKeyAsync(request);

            return response;
        }

        public async Task<GetApiKeysResponse> GetApiKeysAsync(GetApiKeysRequest request)
        {
            GetApiKeysResponse response = await _amazonAPIGateway.GetApiKeysAsync(request);

            return response;
        }

        public async Task<UpdateApiKeyResponse> UpdateApiKeyAsync(UpdateApiKeyRequest request)
        {
            UpdateApiKeyResponse response = await _amazonAPIGateway.UpdateApiKeyAsync(request);

            return response;
        }

        public async Task<DeleteApiKeyResponse> DeleteApiKeyAsync(DeleteApiKeyRequest request)
        {
            DeleteApiKeyResponse response = await _amazonAPIGateway.DeleteApiKeyAsync(request);

            return response;
        }

        #endregion

        #region DomainName Operations

        public async Task<CreateDomainNameResponse> CreateDomainNameAsync(CreateDomainNameRequest request)
        {
            CreateDomainNameResponse response = await _amazonAPIGateway.CreateDomainNameAsync(request);

            return response;
        }
        
        public async Task<GetDomainNameResponse> GetDomainNameAsync(GetDomainNameRequest request)
        {
            GetDomainNameResponse response = await _amazonAPIGateway.GetDomainNameAsync(request);

            return response;
        }
                
        public async Task<GetDomainNamesResponse> GetDomainNamesAsync(GetDomainNamesRequest request)
        {
            GetDomainNamesResponse response = await _amazonAPIGateway.GetDomainNamesAsync(request);

            return response;
        }
                        
        public async Task<UpdateDomainNameResponse> UpdateDomainNameAsync(UpdateDomainNameRequest request)
        {
            UpdateDomainNameResponse response = await _amazonAPIGateway.UpdateDomainNameAsync(request);

            return response;
        }

        public async Task<DeleteDomainNameResponse> DeleteDomainNameAsync(DeleteDomainNameRequest request)
        {
            DeleteDomainNameResponse response = await _amazonAPIGateway.DeleteDomainNameAsync(request);

            return response;
        }



        #endregion      

        #region BasePathMapping resource Operations

        public async Task<CreateBasePathMappingResponse> CreateBasePathMappingAsync(CreateBasePathMappingRequest request)
        {
            CreateBasePathMappingResponse response = await _amazonAPIGateway.CreateBasePathMappingAsync(request);

            return response;
        }

        public async Task<GetBasePathMappingResponse> GetBasePathMappingAsync(GetBasePathMappingRequest request)
        {
            GetBasePathMappingResponse response = await _amazonAPIGateway.GetBasePathMappingAsync(request);

            return response;
        }

        public async Task<GetBasePathMappingsResponse> GetBasePathMappingsAsync(GetBasePathMappingsRequest request)
        {
            GetBasePathMappingsResponse response = await _amazonAPIGateway.GetBasePathMappingsAsync(request);

            return response;
        }

        public async Task<UpdateBasePathMappingResponse> UpdateBasePathMappingAsync(UpdateBasePathMappingRequest request)
        {
            UpdateBasePathMappingResponse response = await _amazonAPIGateway.UpdateBasePathMappingAsync(request);

            return response;
        }

        public async Task<DeleteBasePathMappingResponse> DeleteBasePathMappingAsync(DeleteBasePathMappingRequest request)
        {
            DeleteBasePathMappingResponse response = await _amazonAPIGateway.DeleteBasePathMappingAsync(request);

            return response;
        }

        #endregion

        #region Model resources Operations

        public async Task<CreateModelResponse> CreateModelAsync(CreateModelRequest request)
        {
            CreateModelResponse response = await _amazonAPIGateway.CreateModelAsync(request);

            return response;
        }
        
        public async Task<GetModelResponse> GetModelAsync(GetModelRequest request)
        {
            GetModelResponse response = await _amazonAPIGateway.GetModelAsync(request);

            return response;
        }
                
        public async Task<GetModelsResponse> GetModelsAsync(GetModelsRequest request)
        {
            GetModelsResponse response = await _amazonAPIGateway.GetModelsAsync(request);

            return response;
        }
                        
        public async Task<UpdateModelResponse> UpdateModelAsync(UpdateModelRequest request)
        {
            UpdateModelResponse response = await _amazonAPIGateway.UpdateModelAsync(request);

            return response;
        }
        
        public async Task<DeleteModelResponse> DeleteModelAsync(DeleteModelRequest request)
        {
            DeleteModelResponse response = await _amazonAPIGateway.DeleteModelAsync(request);

            return response;
        }

        #endregion

        #region Method resources Operations

        #endregion

        #region Deployments Operations

        public async Task<CreateDeploymentResponse> CreateDeploymentAsync(CreateDeploymentRequest request)
        {
            CreateDeploymentResponse response = await _amazonAPIGateway.CreateDeploymentAsync(request);

            return response;
        }
        
        public async Task<GetDeploymentResponse> GetDeploymentAsync(GetDeploymentRequest request)
        {
            GetDeploymentResponse response = await _amazonAPIGateway.GetDeploymentAsync(request);

            return response;
        }
       
        public async Task<GetDeploymentsResponse> GetDeploymentsAsync(GetDeploymentsRequest request)
        {
            GetDeploymentsResponse response = await _amazonAPIGateway.GetDeploymentsAsync(request);

            return response;
        }


        public async Task<UpdateDeploymentResponse> UpdateDeploymentAsync(UpdateDeploymentRequest request)
        {
            UpdateDeploymentResponse response = await _amazonAPIGateway.UpdateDeploymentAsync(request);

            return response;
        }


        public async Task<DeleteDeploymentResponse> DeleteDeploymentAsync(DeleteDeploymentRequest request)
        {
            DeleteDeploymentResponse response = await _amazonAPIGateway.DeleteDeploymentAsync(request);

            return response;
        }

        #endregion        

        #endregion
    }
}
