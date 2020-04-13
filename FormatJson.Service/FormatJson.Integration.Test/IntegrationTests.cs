using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormatJson.Integration.Test
{
    [TestClass]
    public class IntegrationTests
    {
        public IntegrationTests()
        {
            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                // Add TestServer
                webHost.UseTestServer();

                // Specify the environment
                webHost.UseEnvironment("Test");

                webHost.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!")));
            });
        }
        [TestMethod]
        public void test()
        {
            Assert.IsTrue(true);
        }
    }
}
