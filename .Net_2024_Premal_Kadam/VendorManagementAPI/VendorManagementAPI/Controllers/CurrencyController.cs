using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly Currency currency;

        public CurrencyController(Currency currencyREF)
        {
            this.currency = currencyREF;
        }

        [HttpGet]
        public IActionResult GetAllCurrencies()
        {
            try
            {
                var cList = currency.GetAllCurrency();
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCurrency([FromBody] Currency currencyREF)
        {
            try
            {
                var msg = currency.AddCurrency(currencyREF);
                return Created("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editCurr/{cCode}")]
        public IActionResult UpdateCurrency(string cCode,[FromBody] Currency currencyREF)
        {
            try
            {
                var msg = currency.UpdateCurrency(cCode,currencyREF);
                return Accepted("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/{currencyCode}")]
        public IActionResult DeleteCurrency(string currencyCode)
        {
            try
            {
                var msg = currency.DeleteCurrency(currencyCode);
                return Accepted(msg);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
