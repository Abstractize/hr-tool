using NUnit.Framework;
using Server.Models;
using Server.Persistence;
using System.Threading.Tasks;

namespace ServerTests.Persistence.Tests
{
    [TestFixture()]
    public class EmployeeDataRepositoryTests : RepositoryTests<EmployeeData,EmployeeDataRepository>
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();
            repository = new EmployeeDataRepository(context);
        }
        [Test(), Order(1)]
        public async Task CreateTest()
        {
            var value = EmployeeData.Empty;
            await base.CreateTest(value);
        }

        [Test(), Order(2)]
        public new async Task GetTest()
        {
            await base.GetTest();
        }

        [Test(), Order(3)]
        public new async Task GetAllTest()
        {
            await base.GetAllTest();
        }
    }
}