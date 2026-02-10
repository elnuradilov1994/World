using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.DAL;
using World.DAL.Repositories.Abstact;
using World.Dtos.Continents;
using World.Dtos.Country;
using World.Entities;

namespace World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _repo;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesPaginate(int page,int size)
        {
            return Ok(await _repo.GetAllPaginatedAsync(page,size));
        }

        [HttpGet]
        public async Task<IActionResult> GetCountry(int id)
        {
            return Ok(await _repo.GetAsync(c=>c.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryDto create)
        {
            var country = _mapper.Map<Country>(create);
            await _repo.AddAsync(country);
            await _repo.SaveAsync();
            return Ok(country);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCountry(int id)
        {
            var deleted = await _repo.GetAsync(c => c.Id == id);
             _repo.RemoveAsync(deleted);
            await _repo.SaveAsync();
            return Ok(deleted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(int id,UpdateCountryDto update)
        {
            var updated = await _repo.GetAsync(c => c.Id == id);
            _mapper.Map(update,updated);
            _repo.UpdateAsync(updated);
            await _repo.SaveAsync();
            return Ok(updated);
        }
    }
}
