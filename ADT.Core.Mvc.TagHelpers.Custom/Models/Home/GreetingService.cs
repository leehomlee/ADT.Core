namespace ADT.Core.Mvc.TagHelpers.Custom.Models.Home
{
    public interface IGreetingService
    {
        string Greet(string name);
    }
    public class GreetingService : IGreetingService
    {
        public string Greet(string name)
        {
            return $"Hello {name}";
        }
    }
}
