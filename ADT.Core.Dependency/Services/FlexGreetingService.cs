using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Dependency.Services
{
    public class FlexGreetingService : IGreetingService
    {
        private readonly string sayWhat;

        public FlexGreetingService(string _sayWhat)
        {
            sayWhat = _sayWhat;
        }

        public string Greet(string to)
        {
            return $"{sayWhat} {to}";
        }
    }
}
