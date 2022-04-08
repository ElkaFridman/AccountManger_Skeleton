using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountServices.Models;

namespace AccountServices.Services
{
    public interface IRequestTypeHandlerFactory
    {
        IRequestTypeHandler GetHandler(QueuedRequest.RequestType type, IRequestHandler requestHandler);
    }
}

