#region Copyright 2022
// -----------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="Dell Inc.">
//      Copyright © 2022, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using Newtonsoft.Json;

namespace AccountServices.Models
{
    public class ErrorMessage
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        public override string ToString()
        {
            return $" Code: {Code}, ErrorMessage: {Message}";
        }
    }
}

