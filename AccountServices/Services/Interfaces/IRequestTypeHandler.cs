#region Copyright 2021
// -----------------------------------------------------------------------
// <copyright file="IRequestTypeHandler.cs" company="Dell Inc.">
//      Copyright © 2021, Dell Inc. or its subsidiaries.  All Rights Reserved.
//      This material is confidential and a trade secret.  Permission to use
//      this work for any purpose must be obtained in writing from Dell Inc.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System.Threading.Tasks;
using AccountServices.Models;

namespace AccountServices.Services
{
    public interface IRequestTypeHandler
    {
        Task CompleteRequest(QueuedRequest request);

        Task<string> RegisterRequest(QueuedRequest request);
    }
}

