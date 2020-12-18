using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Server.Persistence;
using System.Threading.Tasks;

namespace ServerTests.Persistence.Tests
{
    public class RepositoryTests<Model, Repository> where Repository : Repository<Model>
    {
        protected Repository repository;
        protected EmployeeContext context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "Movies Test").Options;
            context = new EmployeeContext(options);
        }

        public async Task CreateTest(Model value)
        {
            value = await repository.Create(value);
            Assert.IsInstanceOf(typeof(Model), value);
        }


        public async Task GetTest()
        {
            var value = await repository.Get(1);
            Assert.IsInstanceOf(typeof(Model), value);
        }


        public async Task GetAllTest()
        {
            var value = await repository.GetAll();
            Assert.IsNotEmpty(value);
        }
    }
}
