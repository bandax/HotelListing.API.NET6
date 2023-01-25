using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Configurations
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
            #endregion
        }
    }
}

