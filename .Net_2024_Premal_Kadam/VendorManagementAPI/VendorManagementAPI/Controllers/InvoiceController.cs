using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;
using System.Text.Json;

namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly VendorManagementContext _context;


        public InvoiceController(VendorManagementContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            try
            {
                var vList = _context.Invoices.ToList();
                return Ok(vList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getInvoiceByNumber/{iNumber}")]
        public IActionResult GetInvoiceByNumber(int iNumber)
        {
            try
            {
                Invoice v = _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefault();
                if (v != null)
                    return Ok(v);
                else
                    throw new Exception("Invoice with code " + iNumber + " is not present");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getByVendor/{vCode}")]
        public IActionResult GetAllInvoicesByVendorCode(string vCode)
        {
            try
            {
                //var customList = JsonSerializer.Deserialize<List<Invoice>>(list);
                int vId = _context.Vendors.Where(v => v.VendorCode == vCode).SingleOrDefault().VendorId;
                var iList = _context.Invoices.Where(i => i.VendorId == vId);
                return Ok(iList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getByCurrency/{cCode}")]
        public IActionResult GetAllInvoicesByCurrencyCode(string cCode)
        {
            try
            {
                //var customList = JsonSerializer.Deserialize<List<Invoice>>(list);
                int cId = _context.Currencies.Where(v => v.CurrencyCode == cCode).SingleOrDefault().CurrencyId;
                var iList = _context.Invoices.Where(i => i.InvoiceCurrencyId == cId);
                return Ok(iList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("countByVendorId")]
        public IActionResult GetAllInvoicesCountByVendorId()
        {
            try
            {
                var list = _context.Invoices.ToList().GroupBy(i => i.VendorId).Select(g => new { VendorId = g.Key, Count = g.Count() });
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddInvoice([FromBody] Invoice invoiceREF)
        {
            try
            {
                if (_context.Invoices.Any(c => c.InvoiceNumber == invoiceREF.InvoiceNumber))
                {
                    return BadRequest("There is already invoice with same number.");
                }

                if(_context.Vendors.Any(v => v.VendorId == invoiceREF.VendorId))
                {
                    if(_context.Currencies.Any(c => c.CurrencyId == invoiceREF.InvoiceCurrencyId))
                    {
                        invoiceREF.InvoiceReceivedDate = DateTime.Now;
                        _context.Invoices.Add(invoiceREF);
                        _context.SaveChanges();
                        IObservable<string> stringObservable = Observable.Return("Invoice Added successfully");
                        return Created("", stringObservable);
                    }
                    else
                    {
                        return NotFound("Currency not present");
                    }
                }
                else
                {
                    return NotFound("Vendor not present");
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{iNumber}")]
        public IActionResult UpdateInvoice(int iNumber,[FromBody] Invoice invoiceREF)
        {
            try
            {
                Invoice invoice = _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefault();

                if (invoice == null)
                {
                    return NotFound("Vendor not found");
                }

                invoice.InvoiceNumber = invoiceREF.InvoiceNumber;
                invoice.InvoiceCurrencyId = invoiceREF.InvoiceCurrencyId;
                invoice.VendorId = invoiceREF.VendorId;
                invoice.InvoiceAmount = invoiceREF.InvoiceAmount;
                invoice.InvoiceDueDate = invoiceREF.InvoiceDueDate;
                invoice.IsActive = invoiceREF.IsActive;
                _context.Entry(invoice).State = EntityState.Modified;
                _context.SaveChanges();
                IObservable<string> stringObservable = Observable.Return("Invoice updated");
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{iNumber}")]
        public IActionResult DeleteInvoice(int iNumber)
        {
            Invoice invoiceREF = _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefault();
            if (invoiceREF == null)
            {
                return NotFound("invoice not found");
            }
            
            _context.Invoices.Remove(invoiceREF);
            _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPost]
        //[Route("export")]
        //public IActionResult ExportInvoiceList()
        //{
        //    try
        //    {
        //        var msg = invoice.ExportInvoiceList();
        //        IObservable<string> stringObservable = Observable.Return(msg);
        //        return Ok(stringObservable);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    
}
}
