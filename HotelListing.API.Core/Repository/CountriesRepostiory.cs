using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Exceptions;
using HotelListing.API.Core.Models.Country;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Core.Repository
{
    public class CountriesRepostiory : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepostiory(HotelListingDbContext context, IMapper mapper): base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CountryDto> GetDetails(int id)
        {
            var country = await _context.Countries
                                        .Include(x => x.Hotels)
                                        .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                                        .FirstOrDefaultAsync( x => x.Id == id);
            
            if(country == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return country;            

        }
    }
}
