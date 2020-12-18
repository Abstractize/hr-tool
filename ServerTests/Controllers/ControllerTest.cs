using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Server.Mapping;
using Server.Persistence;
using Server.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerTests.Controllers.Tests
{
    public class ControllerTest<T> where T : ControllerBase 
    {
        protected Mock<IImageRepository> imageRepository;
        protected Mock<IEmployeeRepository> employeeRepository;
        protected Mock<IEmployeeDataRepository> employeeDataRepository;
        protected IMapper mapper;
        protected T controller;

        [SetUp]
        public void Setup()
        {

            imageRepository = new Mock<IImageRepository>();
            imageRepository.Setup(_ => _.Create(It.IsAny<Image>())).Returns<Image>(i => Task.FromResult(i));
            imageRepository.Setup(_ => _.Get(It.IsAny<int>())).ReturnsAsync(Image.Empty);
            imageRepository.Setup(_ => _.GetAll()).ReturnsAsync(new List<Image>());

            employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(_ => _.Create(It.IsAny<Employee>())).Returns<Employee>(i => Task.FromResult(i));
            employeeRepository.Setup(_ => _.Get(It.IsAny<int>())).ReturnsAsync(Employee.Empty);
            employeeRepository.Setup(_ => _.GetAll()).ReturnsAsync(new List<Employee>());

            employeeDataRepository = new Mock<IEmployeeDataRepository>();
            employeeDataRepository.Setup(_ => _.Create(It.IsAny<EmployeeData>())).Returns<EmployeeData>(i => Task.FromResult(i));
            employeeDataRepository.Setup(_ => _.Get(It.IsAny<int>())).ReturnsAsync(EmployeeData.Empty);
            employeeDataRepository.Setup(_ => _.GetAll()).ReturnsAsync(new List<EmployeeData>());

            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(
                    employeeRepository.Object
                    ));
            }).CreateMapper();
        }
    }
}
