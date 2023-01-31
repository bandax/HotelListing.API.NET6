using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Core.Models.Country;
using HotelListing.API.Core.Models.Hotel;
using HotelListing.API.Core.Models.Users;

namespace HotelListing.API.Core.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            #region "Country Mappings"
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();            
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            #endregion

            #region "Hotel Mappings"
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, GetHotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
            #endregion

            #region "Authentication"
            CreateMap<UserDto, User>().ReverseMap();
            #endregion
        }
    }
}

