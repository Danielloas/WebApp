using AutoMapper;
using WebApp.Data.Identity;

namespace WebApp.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            this.CreateMap<Manager, ManagerModel>()
                //TODO Data transformer "Date"
                .ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date))
                //TODO Data transformer "FullName"
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Id));
            this.CreateMap<ManagerModel, Manager>();
        }
    }
}
