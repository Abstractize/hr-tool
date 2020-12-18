using NUnit.Framework;
using Server.Models;
using Server.Persistence;
using System.Threading.Tasks;

namespace ServerTests.Persistence.Tests
{
    [TestFixture()]
    public class EmployeeRepositoryTests : RepositoryTests<Employee,EmployeeRepository>
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();
            repository = new EmployeeRepository(context);
        }
        [Test(), Order(1)]
        public async Task CreateTest()
        {
            var value = Employee.Empty;
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