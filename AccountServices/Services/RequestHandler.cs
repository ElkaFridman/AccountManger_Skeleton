using System;
using System.Threading.Tasks;
using Serilog;
using AccountServices.Models;

namespace AccountServices.Services
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IDataAccess dataAccess;
        private readonly IRequestTypeHandlerFactory handlerFactory;

        public RequestHandler(IDataAccess dataAccess, IRequestTypeHandlerFactory handlerFactory)
        {
            this.dataAccess = dataAccess;
            this.handlerFactory = handlerFactory;
        }

        public async Task<string> RegisterRequest(QueuedRequest request)
        {
            IRequestTypeHandler handler = handlerFactory.GetHandler(request.Type, this);
            return await handler.RegisterRequest(request);
        }

        public async Task CompleteRequest(string token, QueuedRequest.RequestType type)
        {
            await Task.Delay(5 * 1000);
            QueuedRequest request = await dataAccess.LockAndReturnRequest(token);
            if (request == null)
            {
                return;
            }

            try
            {
                IRequestTypeHandler handler = handlerFactory.GetHandler(type, this);
                await handler.CompleteRequest(request);
            }
            catch (Exception ex)
            {
                request.Status = QueuedRequest.RequestStatus.FAILED;
                request.Message = ex.Message;
                Log.Error(ex, "Caught exception while processing the task {Token}", request.Token);
                await dataAccess.UpdateRequestStatus(request.Token, request);
            }
        }

        public async Task<QueuedRequest> GetStatus(string requestedToken)
        {
            return await dataAccess.GetRequestStatusByToken(requestedToken);
        }

        public async Task<Tenant> GetTenantInfoByUid(string uid)
        {
            return await dataAccess.GetTenantInfoByUid(uid);
        }

        public async Task<Tenant> GetTenantInfoByName(string name)
        {
            return await dataAccess.GetTenantInfoByName(name);
        }

        public async Task<Subscription> GetSubscriptionByUid(string uid)
        {
            return await dataAccess.GetSubscriptionByUid(uid);
        }

        public async Task<Subscription> GetSubscriptionByTenantUid(string tenantId)
        {
            return await dataAccess.GetSubscriptionByTenantUid(tenantId);
        }
    }
}

