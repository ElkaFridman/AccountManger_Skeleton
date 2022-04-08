#region Copyright 2022
// -----------------------------------------------------------------------
// <copyright file="CreateTenantRequest.cs" company="Dell Inc.">
//      Copyright © 2022, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AccountServices.Models
{
    public class CreateTenantRequest
    {
        [Required]
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [Required]
        [JsonProperty(PropertyName = "soldTo")]
        public Contact SoldTo { get; set; }

        [JsonProperty(PropertyName = "itContact")]
        public Contact ItContact { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [Required]
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [Required]
        [JsonProperty(PropertyName = "country")]
        [MaxLength(2)]
        public string Country { get; set; }
    }

    public class Contact
    {
        [JsonProperty(PropertyName = "first")]
        public string First { get; set; }

        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }

        [Required]
        [JsonProperty(PropertyName = "email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}

