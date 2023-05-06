using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAUtils
{
    public static class TestConfigurator
    {
        private static readonly AppSettings appSettings = new();
        public static AppSettings AppSettings => appSettings;

        static TestConfigurator() 
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddEnvironmentVariables()
                .Build();

            configuration.Bind(appSettings);
        }
    }
}
