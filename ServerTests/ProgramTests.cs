using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Server.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [Test()]
        public void CreateHostBuilderTest()
        {
            IHostBuilder host = Program.CreateHostBuilder(new string[] { });
            Assert.IsNotNull(host);
        }
    }
}