#region Copyright 2021
// -----------------------------------------------------------------------
// <copyright file="QueuedRequest.cs" company="Dell Inc.">
//      Copyright © 2021, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System;
using System.ComponentModel;

namespace AccountServices.Models
{
    public class QueuedRequest
    {
        public string Token { get; set; }
        public string UniqueId { get; set; }
        public RequestType Type { get; set; }
        public RequestStatus Status { get; set; }
        public string Message { get; set; }
        public string RequestedData { get; set; }
        public string ParentRequestToken { get; set; }
        public enum RequestStatus
        {
            PENDING,
            IN_PROGRESS,
            FAILED,
            COMPLETED
        }

        public enum RequestType
        {
            [Description("tenant.provisioned")]
            CreateTenant = 0,
            [Description("tenant.stateChange")]
            UpdateTenantState = 1,
            [Description("tenant.subscriptionChange")]
            TenantSubscription = 2,
            SoltuionSubscription = 3,
            SolutionTenantCreation = 4,
            SolutionSubscriptionStatus = 5,
            SolutionTenantCreationStatus = 6,
            UpdateTenantSubscriptionV2 = 7,
            CreateTenantV2 = 8,
            CreateTenantSubscriptionV2 = 9
        }

        public static RequestStatus ParseRequestStatus(string status)
        {
            return (RequestStatus)Enum.Parse(typeof(RequestStatus), status);
        }

        public static RequestType ParseRequestType(string type)
        {
            return (RequestType)Enum.Parse(typeof(RequestType), type);
        }
    }
}

