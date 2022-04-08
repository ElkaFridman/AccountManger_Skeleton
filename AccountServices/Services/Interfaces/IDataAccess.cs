/*
 * ©Copyright 2018 Dell, Inc., All Rights Reserved.
 * This material is confidential and a trade secret.  Permission to use this
 * work for any purpose must be obtained in writing from Dell, Inc.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountServices.Models;

namespace AccountServices.Services
{
    public interface IDataAccess
    {

        /// <summary>
        /// Used to retrieve the tokens of all pending requests. Meant to be used for recovery purposes.
        /// </summary>
        /// <returns></returns>
        Task<List<(string token, QueuedRequest.RequestType type)>> GetAllPendingRequests();

        /// <summary>
        /// Used to update the status of a tenant creation request. 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="request"></param>
        Task UpdateRequestStatus(string token, QueuedRequest request);

        /// <summary>
        /// Creates a new tenant entry.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <exception cref="TenantAlreadyExistsException">A TenantAlreadyExistsException will be thrown if
        /// this tenant already exists.</exception>
        /// <returns>It will return the Uui of the new tenant</returns>
        Task<string> CreateTenant(Tenant tenantInfo);

        Task<Tenant> GetTenantInfoByUid(string uid);
        Task<Tenant> GetTenantInfoByName(string name);

        Task<Subscription> GetSubscriptionByUid(string uid);
        Task<Subscription> GetSubscriptionByTenantUid(string tenantId);

        Task<SubscriptionProduct> GetSubscriptionAddonBySubscriptionUidAndSku(string subscriptionId, string sku);
        Task InsertSubscriptionAddon(SubscriptionProduct subscriptionProduct);
        Task UpdateSubscriptionAddon(SubscriptionProduct subscriptionProduct);

        Task<QueuedRequest> GetRequestStatusByToken(string token);
        Task<QueuedRequest> GetRequestStatusByUniqueId(string uniqueId);

        Task<List<QueuedRequest>> GetRequestStatusByTenant(string customerTenantId, QueuedRequest.RequestType type);

        Task<QueuedRequest> LockAndReturnRequest(string token);

        Task<string> RegisterNewRequest(QueuedRequest request);

        Task InsertTenantSubscription(Subscription subscription);
        Task UpdateTenantSubscription(Subscription subscription);

        Task InsertCallbackRequestDetails(Guid requestId, string requestDetailsJson);

        Task<string> GetCallbackRequestDetails(Guid requestId);
    }
}
