using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.Layout.Models.Home
{
    public interface IGreetingService
    {
        string Greet(string firstname, string surname);
    }

    public class GreetingService : IGreetingService
    {
        public string Greet(string firstname, string surname)
        {
            return $"Hello {firstname} {surname}";
        }
    }
}
