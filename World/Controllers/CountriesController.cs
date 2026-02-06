using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.Dtos.Continents;
using World.Dtos.Country;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly WoldDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(WoldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _context.Countries.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryDto countryDto)
        {
            var result = _mapper.Map<Country>(countryDto);
            await _context.Countries.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleted = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            _context.Countries.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(UpdateCountryDto updateCountry, int id)
        {
            var updated = await _context.Continents.FirstOrDefaultAsync(c => c.Id == id);
            var result = _mapper.Map(updateCountry, updated);
            _context.Continents.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
