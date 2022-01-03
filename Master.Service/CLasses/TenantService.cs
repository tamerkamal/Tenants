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

            CreateUserPoolResponse createUserPoolResponse = await _userPoolService.CreateUserPoolAsync(new CreateUserPoolRequest
            {

            });

            if (createUserPoolResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {

            }

            return new CreateTenantResDTO();
        }

        #endregion

        #region Helper Methods

        public async Task<CreateSubscriptionResDTO> CreateSubscriptionAsync(CreateSubscriptionReqDTO createSubscriptionReqDTO)
        {
            // Declare Repositories   
            var subscriptionRepository = _unitOfWork.GetRepository<BaseRepository<Subscription>>();

            await  subscriptionRepository.InsertAsync(new Subscription
            {
                
            });

            return new CreateSubscriptionResDTO();
        }

        #endregion

        #endregion
    }
}
