using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware.Options.Service
{
    public interface IMessageService
    {
        string FormatMessage(string message);
    }
}
