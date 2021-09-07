using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class ASetup
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Orders>();

            Configuration = builder.Build();
        }

        /// <summary>
        /// If this test fails (and all other tests because of it) you probably need to set the user secrets 'ClientId' and 'ClientSecret'
        /// Example of how to set one of the usersecrets: 'dotnet user-secrets set ClientSecret MySecretKeyxyz12345' ran in the testproject
        /// More information about user secrets can be found here: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
        /// </summary>
        [TestMethod]
        public async Task CheckCredentialsSet()
        {
            try
            {
                testClientId = Configuration["ClientId"];
                testClientSecret = Configuration["ClientSecret"];
            }
            catch
            {
                throw new Exception("The client Id or client Secret was not set to a value");
            }
            if (string.IsNullOrWhiteSpace(testClientId) || string.IsNullOrWhiteSpace(testClientSecret))
            {
                throw new Exception("The client Id or client Secret was not set to a value");
            }
        }
    }
}
