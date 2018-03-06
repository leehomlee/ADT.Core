using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.Razor.Models.Home
{
    public interface IGreeter
    {
        string Greet(string firstname, string surname);
    }

    public class Greeter : IGreeter
    {
        public string Greet(string firstname, string surname)
        {
            return $"Hello {firstname} {surname}";
        }
    }
}
