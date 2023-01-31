using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Models.Hotel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using HotelListing.API.Core.Models;
using HotelListing.API.Core.Exceptions;
using HotelListing.API.Core.Models.Country;
using Newtonsoft.Json;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _repository;

       

        public HotelsController(IMapper mapper, IHotelsRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
        {
            var hotelsDto = await _repository.GetAllAsync<GetHotelDto>();            
            return hotelsDto;
        }

        // GET: api/Hotes?StartIndex=0&pagesize=10&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetHotelDto>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
        {
            var pagedHotelsResult = await _repository.GetAllAsync<GetHotelDto>(queryParameters);            
            return pagedHotelsResult;
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotelDto = await _repository.GetAsync<HotelDto>(id);            
            return Ok(hotelDto);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updateHotelDto)
        {
            if (id != updateHotelDto.Id)
            {
                throw new BadRequestException(nameof(PutHotel), JsonConvert.SerializeObject(updateHotelDto));
            }

            try
            {
                await _repository.UpdateAsync<UpdateHotelDto>(id, updateHotelDto);                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<HotelDto>> PostHotel(CreateHotelDto createHotelDto)
        {            
            var hotel = await _repository.AddAsync<CreateHotelDto, HotelDto>(createHotelDto);            
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {           
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
