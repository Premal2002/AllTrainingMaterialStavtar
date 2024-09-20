using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstTest.Model;

namespace CodeFirstTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly VendorManagementContext _context;
        private readonly Currency currency;

        public CurrenciesController(VendorManagementContext context, Currency currencyREF)
        {
            _context = context;
            this.currency = currencyREF;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            try
            {
                var cList = currency.GetAllCurrency(_context.Currencies.ToList());
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Currencies/5
        [HttpGet("{cCode}")]
        public async Task<ActionResult<Currency>> GetCurrency(string cCode)
        {
            try
            {
                var v = currency.GetCurrencyByCode(cCode, _context.Currencies.ToList());
                return Ok(v);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency currency)
        {
            if (id != currency.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency([FromBody]Currency currency)
        {
            try
            {
                var msg = currency.AddCurrency(currency,_context.Currencies.ToList());
                return Created("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currencies.Any(e => e.CurrencyId == id);
        }
    }
}
