using AutoMapper;
using api_infor_cell.src.Models;
using api_infor_cell.src.Shared.DTOs;



namespace api_infor_cell.src.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {            
            #region MASTER DATA
            CreateMap<UpdateUserDTO, User>().ReverseMap();
            
            CreateMap<CreateProfileUserDTO, ProfileUser>().ReverseMap();
            CreateMap<UpdateProfileUserDTO, ProfileUser>().ReverseMap();
            #endregion
        }
    }

    
}