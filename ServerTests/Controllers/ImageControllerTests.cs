using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Server.Controllers;
using Server.Models;
using System.IO;
using System.Threading.Tasks;


namespace ServerTests.Controllers.Tests
{
    [TestFixture()]
    public class ImageControllerTests : ControllerTest<ImageController>
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();
            this.controller = new ImageController(this.imageRepository.Object,mapper);
        }
        [Test()]
        public async Task CreateImageTest()
        {
            var fileMock = new Mock<IFormFile>();

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;

            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var image = await this.controller.Post(fileMock.Object);

            var objectResponse = image as ObjectResult;
            Assert.AreEqual(200, objectResponse.StatusCode);
        }

        [Test()]
        public async Task GetImageTest()
        {
            var image = await this.controller.Get(0);
            Assert.IsInstanceOf<FileContentResult>(image);
        }
    }
}