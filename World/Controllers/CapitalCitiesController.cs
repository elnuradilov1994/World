using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.Dtos.CapitalCity;
using World.Dtos.Country;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CapitalCitiesController : ControllerBase
    {
        private readonly WorldDbContext _context;
        private readonly IMapper _mapper;

        public CapitalCitiesController(WorldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize("User")]
        public async Task<IActionResult> GetAllCapitalCities()
        {
            var result = await _context.CapitalCities.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCapitalCityById(int id)
        {
            var result = await _context.CapitalCities.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCapitalCity(CreateCapitalCityDto cityDto)
        {
            var result = _mapper.Map<CapitalCity>(cityDto);
            await _context.CapitalCities.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCapitalCity(int id)
        {
            var deleted = await _context.CapitalCities.FirstOrDefaultAsync(c => c.Id == id);
            _context.CapitalCities.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCapitalCity(UpdateCapitalCityDto updateCityDto , int id)
        {
            var updated = await _context.CapitalCities.FirstOrDefaultAsync(c => c.Id == id);
            var result = _mapper.Map(updateCityDto, updated);
            _context.CapitalCities.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
