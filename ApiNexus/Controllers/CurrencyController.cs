using Microsoft.AspNetCore.Mvc;

namespace ApiNexus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly Services.CurrencyService _currencyService;
        public CurrencyController(Services.CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency(string from, string to, decimal amount)
        {
            var result = await _currencyService.ConvertCurrency(from, to, amount);
            if (result == null) return BadRequest("Currency conversion failed.");
            return Ok(new { From = from, To = to, Amount = amount, ConvertedAmount = result });
        }
    }
}
