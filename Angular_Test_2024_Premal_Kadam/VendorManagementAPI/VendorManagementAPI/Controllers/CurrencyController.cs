using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;
using VendorManagementAPI.DTO;
using VendorManagementAPI.Models;

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
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllCurrencies()
        {
            try
            {
                var cList = await _context.Currencies.ToListAsync();
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{pageNo}")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllCurrencies(int pageNo, int pageSize = 5)
        {
            try
            {
                var count = _context.Currencies.Count();
                var cList = await _context.Currencies.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                var result = new
                {
                    count = count,
                    cList = cList
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getCurrencyByCode/{cCode}")]
        public async Task<ActionResult<Currency>> GetCurrencyByCode(string cCode)
        {
            try
            {
                Currency v = await _context.Currencies.Where(c => c.CurrencyCode == cCode).SingleOrDefaultAsync();
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
        public async Task<ActionResult> AddCurrency([FromBody] CurrencyDto currencyREF)
        {
            try
            {
                if(await _context.Currencies.AnyAsync(c => c.CurrencyCode == currencyREF.CurrencyCode))
                {
                    return BadRequest("There is already currency with same code.");
                }
                Currency currency = new Currency()
                {
                    CurrencyCode = currencyREF.CurrencyCode,
                    CurrencyName = currencyREF.CurrencyName
                };
                _context.Currencies.Add(currency);
                _context.SaveChangesAsync();
                IObservable<string> stringObservable = Observable.Return("Currency Added successfully");
                return Created("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cCode}")]
        public async Task<ActionResult> UpdateCurrency(string cCode,[FromBody] CurrencyDto newcurrencyREF)
        {
            try
            {
                Currency currencyREF = await _context.Currencies.Where(c => c.CurrencyCode == cCode).SingleOrDefaultAsync();

                if (currencyREF == null)
                {
                    return NotFound("Currency not found"); 
                }

                currencyREF.CurrencyName = newcurrencyREF.CurrencyName;
                currencyREF.CurrencyCode = newcurrencyREF.CurrencyCode;
                _context.Entry(currencyREF).State = EntityState.Modified;
                _context.SaveChangesAsync();
                IObservable<string> stringObservable = Observable.Return("currency upadated");
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{currencyCode}")]
        public async Task<ActionResult> DeleteCurrency(string currencyCode)
        {
            Currency currencyREF = await _context.Currencies.Where(c => c.CurrencyCode == currencyCode).SingleOrDefaultAsync();
            if (currencyREF == null)
            {
                return NotFound("Currency not found");
            }else if(_context.Invoices.Any(i => i.CurrencyId == currencyREF.CurrencyId))
            {
                return BadRequest("Currency is linked with the invoices, can't delete it.");
            }

            _context.Currencies.Remove(currencyREF);
            _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
