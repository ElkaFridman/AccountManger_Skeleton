#region Copyright 2022
// -----------------------------------------------------------------------
// <copyright file="Tenant.cs" company="Dell Inc.">
//      Copyright © 2022, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

namespace AccountServices.Models
{
    public class Tenant
    {

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        /// <summary>
        /// Tenant name. This must be unique. Only alphanumeric characters, 
        /// including space and underscore.
        /// </summary>
        public string CustomerTenantId { get; set; }

        /// <summary>
        /// Readable name of tenant.
        /// </summary>
        public string CustomerTenantName { get; set; }

        /// <summary>
        /// Administrator email address. This person might receive
        /// emails from services during provisioning. 
        /// NOTE: A HUGE assumption has been made that this email has been
        /// verified by the ODIN side before being sent to us. Therefore,
        /// we do not carry out a verification process.
        /// </summary>
        public string SetupAdmin { get; set; }

        /// <summary>
        /// Tenant Unique ID, internally created by DWS.
        /// </summary>
        public string Uid { get; set; }
    }
}

