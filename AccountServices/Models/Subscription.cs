#region Copyright 2021
// -----------------------------------------------------------------------
// <copyright file="Subscription.cs" company="Dell Inc.">
//      Copyright © 2021, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AccountServices.Models.RequestStatus;

namespace AccountServices.Models
{
    public class CreateSubscriptionRequest
    {
        [Required]
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid seat count")]
        [JsonProperty(PropertyName = "seatCount")]
        public int SeatCount { get; set; }
    }
}

