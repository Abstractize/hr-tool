using AutoMapper;
using Server.Persistence;
using System;
using System.Linq;

namespace Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IEmployeeRepository employeeRepository)
        {
            string host = Environment.GetEnvironmentVariable("URL");
            #region Domain to Resource
            CreateMap<Models.Image, Controllers.Resources.Image>()
                .ForMember(im => im.Id, opt => opt.MapFrom(im => im.IdImage))
                .ForMember(im => im.Url, opt => opt.MapFrom(im => $"{host}/image/{im.IdImage}"));

            CreateMap<Models.Employee, Controllers.Resources.Employee>()
                 .ForMember(emp => emp.Id, opt => opt.MapFrom(empd => empd.IdEmployee))
                 .ForMember(emp => emp.EmployeeId, opt => opt.MapFrom(empd => empd.EmployeeId))
                 .AfterMap((model, resource) =>
                 {
                     Models.EmployeeData data = null;
                     model.EmployeeDatumIdEmployeeNavigations.ToList().ForEach(empData =>
                     {
                         if (data == null || DateTime.Compare(data.RegisterDate, empData.RegisterDate) < 0)
                             data = empData;
                     });
                     resource.Picture = new Controllers.Resources.Image
                     {
                         Id = data.IdImageNavigation.IdImage,
                         Url = $"{host}/image/{data.IdImageNavigation.IdImage}"
                     };
                     resource.Name = data.Name;
                     resource.PhoneNumber = data.PhoneNumber;
                     resource.Email = data.Email;
                     resource.HireDate = data.HireDate;
                     if(data.IdManagerNavigation != null)
                        resource.ManagerId = data.IdManagerNavigation.EmployeeId;
                 });

            CreateMap<Models.EmployeeData, Controllers.Resources.Employee>()
                 .ForMember(emp => emp.Id, opt => opt.MapFrom(empd => empd.IdEmployee))
                 .ForMember(emp => emp.EmployeeId, opt => opt.MapFrom(empd => empd.IdEmployeeNavigation.EmployeeId))
                 .ForMember(emp => emp.Name, opt => opt.MapFrom(empd => empd.Name))
                 .ForMember(emp => emp.Picture, opt => opt.MapFrom(empd => empd.IdImageNavigation))
                 .ForMember(emp => emp.PhoneNumber, opt => opt.MapFrom(empd => empd.PhoneNumber))
                 .ForMember(emp => emp.Email, opt => opt.MapFrom(empd => empd.Email))
                 .ForMember(emp => emp.HireDate, opt => opt.MapFrom(empd => empd.HireDate))
                 .ForMember(emp => emp.ManagerId, opt => opt.MapFrom(empd => empd.IdManagerNavigation.EmployeeId));

            #endregion
            #region Resource to Domain
            CreateMap<Controllers.Resources.Image, Models.Image>()
                .ForMember(im => im.IdImage, opt => opt.MapFrom(im => im.Id))
                .ForMember(im => im.Data, opt => opt.Ignore());

            CreateMap<Controllers.Resources.Employee, Models.Employee>()
                .ForMember(emp => emp.IdEmployee, opt => opt.MapFrom(emp => emp.Id))
                .ForMember(emp => emp.EmployeeId, opt => opt.MapFrom(emp => emp.EmployeeId));

            CreateMap<Controllers.Resources.Employee, Models.EmployeeData>()
                .ForMember(empd => empd.IdEmployeeData, opt => opt.Ignore())
                .ForMember(empd => empd.RegisterDate, opt => opt.Ignore())
                .ForMember(empd => empd.IdEmployee, opt => opt.MapFrom(emp => emp.Id))
                .ForMember(empd => empd.Name, opt => opt.MapFrom(emp => emp.Name))
                .ForMember(empd => empd.IdImage, opt => opt.MapFrom(emp => emp.Picture.Id))
                .ForMember(empd => empd.PhoneNumber, opt => opt.MapFrom(emp => emp.PhoneNumber))
                .ForMember(empd => empd.Email, opt => opt.MapFrom(emp => emp.Email))
                .ForMember(empd => empd.HireDate, opt => opt.MapFrom(emp => emp.HireDate))
                .AfterMap((employee, employeeData) =>
                {
                    if(employee.ManagerId != null)
                        employeeData.IdManager = employeeRepository.GetAll()
                            .Result
                            .FirstOrDefault(emp => emp.EmployeeId == employee.ManagerId)
                            .IdEmployee;
                });
            #endregion
        }
    }
}
