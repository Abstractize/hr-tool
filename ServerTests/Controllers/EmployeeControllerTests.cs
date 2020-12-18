using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Server.Controllers;
using Server.Controllers.Resources;
using System.Threading.Tasks;

namespace ServerTests.Controllers.Tests
{
    [TestFixture()]
    public class EmployeeControllerTests : ControllerTest<EmployeeController>
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();
            this.controller = new EmployeeController(this.mapper,this.employeeRepository.Object, this.employeeDataRepository.Object);
        }

        [Test()]
        public async Task PostTest()
        {
            var employee = await this.controller.Post(Employee.Empty);
            Assert.IsInstanceOf<ObjectResult>(employee);
            var objectResult = employee as ObjectResult;
            Assert.AreEqual(200, objectResult.StatusCode);
        }
         
        [Test()]
        public async Task DeleteTest()
        {
            var employee = await this.controller.Delete(0);
            Assert.IsInstanceOf<ObjectResult>(employee);
            var objectResult = employee as ObjectResult;
            Assert.AreEqual(200, objectResult.StatusCode);
        }

        [Test()]
        public async Task GetTest()
        {
            var employee = await this.controller.Get(0);
            Assert.IsInstanceOf<ObjectResult>(employee);
            var objectResult = employee as ObjectResult;
            Assert.AreEqual(200, objectResult.StatusCode);
        }

        [Test()]
        public async Task GetAllTest()
        {
            var employee = await this.controller.GetAll();
            Assert.IsInstanceOf<ObjectResult>(employee);
            var objectResult = employee as ObjectResult;
            Assert.AreEqual(200, objectResult.StatusCode);
        }

        [Test()]
        public async Task PutTest()
        {
            var employee = await this.controller.Put(Employee.Empty);
            Assert.IsInstanceOf<ObjectResult>(employee);
            var objectResult = employee as ObjectResult;
            Assert.AreEqual(200, objectResult.StatusCode);
        }
    }
}