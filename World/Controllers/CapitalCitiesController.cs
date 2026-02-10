using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.DAL.Repositories.Abstact;
using World.Dtos.CapitalCity;
using World.Dtos.Country;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CapitalCitiesController : ControllerBase
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;

        public CapitalCitiesController(WorldDbContext context, IMapper mapper, ICityRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpGet]
        [Authorize("User")]
        public async Task<IActionResult> GetAllCapitalCities()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCapitalCityById(int id)
        {
            var result = await _repo.GetAsync(c => c.Id == id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCapitalCity(CreateCapitalCityDto cityDto)
        {
            var result = _mapper.Map<CapitalCity>(cityDto);
            await _repo.AddAsync(result);
            await _repo.SaveAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCapitalCity(int id)
        {
            var deleted = await _repo.GetAsync(c => c.Id == id);
            _repo.RemoveAsync(deleted);
            await _repo.SaveAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCapitalCity(UpdateCapitalCityDto updateCityDto , int id)
        {
            var updated = await _repo.GetAsync(c => c.Id == id);
            var result = _mapper.Map(updateCityDto, updated);
            _repo.UpdateAsync(result);
            await _repo.SaveAsync();
            return Ok();
        }
    }
}
