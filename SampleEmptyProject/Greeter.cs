using Microsoft.Extensions.Configuration;

namespace SampleEmptyProject
{
    public class Greeter : IGreeter
    {
        private IConfiguration _config;
        public Greeter(IConfiguration config)
        {
            _config = config;
        }

        public string GetMessageOfTheDay()
        {
            return _config["Greetings"].ToString();
        }
    }
}
