using FormatJson.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FormatJson.Integration.Test
{
    [TestClass]
    public class IntegrationTests
    {
        IHostBuilder hostBuilder;
        public IntegrationTests()
        {
            hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                // Add TestServer
                webHost.UseTestServer();
                webHost.UseStartup<Startup>();
            });

        }

        [TestMethod]
        public async Task ValidFilePath_returns_success()
        {
            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();
            string path = Path.Combine(Environment.CurrentDirectory, "test1.json");
            var response = await client.PostAsync("/formatter/json", new StringContent("test1.json", Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task InValidFilePath_returns_NotFound()
        {
            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();
            string path = Path.Combine(Environment.CurrentDirectory, "test3.json");
            var response = await client.PostAsync("/formatter/json", new StringContent(path, Encoding.UTF8, "application/json"));

            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
