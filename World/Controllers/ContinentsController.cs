using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.DAL.Repositories.Abstact;
using World.Dtos.Continents;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly IContinentRepository _repo;
        private readonly IMapper _mapper;

        public ContinentsController(WorldDbContext context, IMapper mapper, IContinentRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContinents()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetContinentById(int id)
        {
            var result = await _repo.GetAsync(c=> c.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContinent(CreateContinentDto continentDto)
        {
            var result = _mapper.Map<Continent>(continentDto);
            await _repo.AddAsync(result);
            await _repo.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContinent(int id)
        {
            var deleted = await _repo.GetAsync(c => c.Id == id);
            _repo.RemoveAsync(deleted);
            await _repo.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContinent(UpdateContinentDto updateContinent, int id)
        {
            var updated = await _repo.GetAsync(c => c.Id == id);
            var result = _mapper.Map(updateContinent,updated);
            _repo.UpdateAsync(result);
            await _repo.SaveAsync();
            return Ok();
        }
    }
}
