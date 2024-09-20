using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;

namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly VendorManagementContext _context;

        public CurrencyController(Currency currencyREF, VendorManagementContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAllCurrencies()
        {
            try
            {
                var cList = _context.Currencies.ToList();
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
                Currency v = _context.Currencies.Where(c => c.CurrencyCode == cCode).SingleOrDefault();
                if (v != null)
                    return Ok(v);
                else
                    throw new Exception("Currency with code " + cCode + " is not present");
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
                if(_context.Currencies.Any(c => c.CurrencyCode == currencyREF.CurrencyCode))
                {
                    return BadRequest("There is already currency with same code.");
                }
                _context.Currencies.Add(currencyREF);
                _context.SaveChanges();
                IObservable<string> stringObservable = Observable.Return("Currency Added successfully");
                return Created("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cCode}")]
        public IActionResult UpdateCurrency(string cCode,[FromBody] Currency newcurrencyREF)
        {
            try
            {
                Currency currencyREF = _context.Currencies.Where(c => c.CurrencyCode == cCode).SingleOrDefault();

                if (currencyREF == null)
                {
                    return NotFound("Currency not found"); 
                }

                currencyREF.CurrencyName = newcurrencyREF.CurrencyName;
                currencyREF.CurrencyCode = newcurrencyREF.CurrencyCode;
                _context.Entry(currencyREF).State = EntityState.Modified;
                _context.SaveChanges();
                IObservable<string> stringObservable = Observable.Return("currency upadated");
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
            Currency currencyREF = _context.Currencies.Where(c => c.CurrencyCode == currencyCode).SingleOrDefault();
            if (currencyREF == null)
            {
                return NotFound("Currency not found");
            }else if(_context.Invoices.Any(i => i.InvoiceCurrencyId == currencyREF.CurrencyId))
            {
                return BadRequest("Currency is linked with the invoices, can't delete it.");
            }

            _context.Currencies.Remove(currencyREF);
            _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
