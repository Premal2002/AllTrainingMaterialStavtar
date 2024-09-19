using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reactive.Linq;

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

        [HttpGet("getCurrencyByCode/{cCode}")]
        public IActionResult GetCurrencyByCode(string cCode)
        {
            try
            {
                var v = currency.GetCurrencyByCode(cCode);
                return Ok(v);
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
                IObservable<string> stringObservable = Observable.Return(msg);
                return Created("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cCode}")]
        public IActionResult UpdateCurrency(string cCode,[FromBody] Currency currencyREF)
        {
            try
            {
                var msg = currency.UpdateCurrency(cCode,currencyREF);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{currencyCode}")]
        public IActionResult DeleteCurrency(string currencyCode)
        {
            try
            {
                var msg = currency.DeleteCurrency(currencyCode);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Accepted(stringObservable);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
