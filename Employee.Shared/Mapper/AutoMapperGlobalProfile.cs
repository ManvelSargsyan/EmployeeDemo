using AutoMapper;
using Employee.Entities;
using Employee.ServiceModels;
using Employee.ViewModels;

namespace Employee.Shared
{
    public class AutoMapperGlobalProfile : Profile
    {
        public AutoMapperGlobalProfile()
        {
            CreateMap<EmployeeViewModel, EmployeeServiceModel>().ReverseMap();
            CreateMap<EmployeeServiceModel, EmployeeEntity>()
                .ForMember(dest => dest.CreateDate, option => option.Ignore());
            CreateMap<EmployeeEntity, EmployeeServiceModel>();
        }
    }
}
