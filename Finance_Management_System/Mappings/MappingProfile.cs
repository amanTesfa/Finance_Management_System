using AutoMapper;
using Finance_Management_System.Models.Entities;
namespace Finance_Management_System.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            // reverse mapping if needed
            CreateMap<UserDTO, User>();
        }
    }
}

