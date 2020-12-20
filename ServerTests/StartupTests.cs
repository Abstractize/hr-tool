using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Server;
using Server.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Tests
{
    [TestFixture()]
    public class StartupTests
    {
        Startup startup;
        [SetUp]
        public void Setup()
        {
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x["DefaultConnection"]).Returns("TestConnectionString");
            Mock<Microsoft.Extensions.Configuration.IConfiguration> configurationStub = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            startup = new Startup(configurationStub.Object);
        }

        [Test()]
        public void ConfigureServicesTest()
        {
            //  Act
            IServiceCollection services = new ServiceCollection();
            startup.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<ImageController>();
            //  Assert
            var serviceProvider = services.BuildServiceProvider();

            var controller = serviceProvider.GetService<ImageController>();
            Assert.IsNotNull(controller);
        }
    }
}