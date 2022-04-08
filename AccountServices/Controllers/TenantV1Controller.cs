#region Copyright 2022
// -----------------------------------------------------------------------
// <copyright file="TenantV1Controller.cs" company="Dell Inc.">
//      Copyright © 2022, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

#region Copyright 2022
// -----------------------------------------------------------------------
// <copyright file="TenantV1Controller.cs" company="Dell Inc.">
//      Copyright © 2022, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using AccountServices.Models;
using AccountServices.Services;


namespace AccountServices.Controllers
{
    [Route("/api/v1")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class TenantV1Controller : ControllerBase
    {
        private const string SubscriptionNotFoundMessage = "Subscription not found";
        private const string CustomerNotFoundMessage = "Customer not found";
        private const string RequestNotFoundMessage = "Request not found";

        private readonly IRequestHandler requestHandler;

        public TenantV1Controller(IRequestHandler requestHandler)
        {
            this.requestHandler = requestHandler;
        }

        [HttpPost("tenants")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTenantRequest request)
        {
            Log.Information("Received create tenant request for customer with name {Name}", request.Name);
            return Accepted();
        }

        [HttpPost("tenants/{tenantId}/subscriptions")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> CreateTenantSubscription([FromRoute] Guid tenantId, [FromBody] CreateSubscriptionRequest request)
        {
            Log.Information("Received create subscription request for customer {CustomerId}", tenantId);
            return Accepted();
        }

        [HttpGet("queue/{token}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> RequestStatus([FromRoute] Guid token)
        {
            Log.Information("Received queue request for token {Token}", token);
            return Accepted();
            
        }
    }
}
