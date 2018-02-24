using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Dependency.Services
{
    public interface IGreetingService
    {
        string Greet(string to);
    }
}
