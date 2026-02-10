using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.Dtos.Continents;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly WorldDbContext _context;
        private readonly IMapper _mapper;

        public ContinentsController(WorldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContinents()
        {
            var result = await _context.Continents.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetContinentById(int id)
        {
            var result = await _context.Continents.FirstOrDefaultAsync(c=> c.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContinent(CreateContinentDto continentDto)
        {
            var result = _mapper.Map<Continent>(continentDto);
            await _context.Continents.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContinent(int id)
        {
            var deleted = await _context.Continents.FirstOrDefaultAsync(c => c.Id == id);
            _context.Continents.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContinent(UpdateContinentDto updateContinent, int id)
        {
            var updated = await _context.Continents.FirstOrDefaultAsync(c => c.Id == id);
            var result = _mapper.Map(updateContinent,updated);
            _context.Continents.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
