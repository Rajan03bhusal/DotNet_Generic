using AutoMapper;

namespace GenericProject
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
          CreateMap<SuperHero, SuperHeroDto>()
                .ForMember(dest=>dest.FullName,opt=>opt.MapFrom(Src=>Src.FirstName +" "+Src.LastName))
                .ReverseMap();
        }
    }
}
