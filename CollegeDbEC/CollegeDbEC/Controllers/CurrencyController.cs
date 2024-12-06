using CollegeDbEC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeDbEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
           _appDbContext = appDbContext;
        }


        [HttpGet("GetAllCurrencies")]
        public IActionResult GetAllCurrencies()
        {
            var result = _appDbContext.currencies.ToList();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCurrenciesByIdAsync(int id)
        {
            var result = await _appDbContext.currencies.Where(x => x.Id == id)
                                                       .Select(x => new CurrencyDto
                                                       {
                                                           CurrencyId = x.Id,
                                                           CurrencyTitle = x.title
                                                       }).ToListAsync();

            return Ok(result);
        }
    }
}
