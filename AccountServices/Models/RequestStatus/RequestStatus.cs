#region Copyright 2021
// -----------------------------------------------------------------------
// <copyright file="RequestStatus.cs" company="Dell Inc.">
//      Copyright © 2021, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AccountServices.Models.RequestStatus
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestStatus
    {
        FAILED,
        COMPLETED
    }
}
