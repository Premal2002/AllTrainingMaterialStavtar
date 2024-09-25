using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;
using System.Text.Json;
using VendorManagementAPI.DTO;
using VendorManagementAPI.Models;

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

        [HttpGet("getInvoiceByNumber/{iNumber}")]
        public async Task<ActionResult<Invoice>> GetInvoiceByNumber(int iNumber)
        {
            try
            {
                Invoice v = await _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefaultAsync();
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


        [HttpGet("getFilteredInvoices/{cId}/{vId}/{pageNo}")]
        public async Task<ActionResult<Invoice>> GetFilteredInvoices(int cId,int vId,int pageNo,int pageSize = 5)
        {
            try
            {
                //var list = _context.Invoices
                //                .Join(_context.Vendors,
                //                      invoice => invoice.VendorId,
                //                      vendor => vendor.VendorId,
                //                      (invoice, vendor) => new { invoice, vendor })
                //                .Join(_context.Currencies,
                //                      invVendor => invVendor.invoice.CurrencyId,
                //                      currency => currency.CurrencyId,
                //                      (invVendor, currency) => new
                //                      {
                //                          InvoiceNumber = invVendor.invoice.InvoiceNumber,
                //                          CurrencyCode = currency.CurrencyCode,
                //                          VendorName = invVendor.vendor.VendorLongName,
                //                          Amount = invVendor.invoice.InvoiceAmount,
                //                          ReceivedDate = invVendor.invoice.InvoiceReceivedDate,
                //                          DueDate = invVendor.invoice.InvoiceDueDate,
                //                          IsActive = invVendor.invoice.IsActive
                //                      });
                var iList = new List<Invoice>();
                var count = _context.Invoices.Count();
                iList =await _context.Invoices.Where(i => i.VendorId == (vId==0?i.VendorId:vId) && i.CurrencyId== (cId==0 ? i.CurrencyId : cId)).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                var result = new
                {
                    count = count,
                    iList = iList
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("countByVendorId")]
        public async Task<ActionResult<Invoice>> GetAllInvoicesCountByVendorId()
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
        public async Task<ActionResult> AddInvoice([FromBody] InvoiceDto invoiceREF)
        {
            try
            {
                if (await _context.Invoices.AnyAsync(c => c.InvoiceNumber == invoiceREF.InvoiceNumber))
                {
                    return BadRequest("There is already invoice with same number.");
                }

                if(await _context.Vendors.AnyAsync(v => v.VendorId == invoiceREF.VendorId))
                {
                    var i = invoiceREF;
                    if(await _context.Currencies.AnyAsync(c => c.CurrencyId == invoiceREF.CurrencyId))
                    {
                        //var vendor = _context.Vendors.Find(invoiceREF.VendorId);
                        //var currency = _context.Currencies.Find(invoiceREF.CurrencyId);
                        var invoice = new Invoice()
                        {
                            InvoiceNumber = invoiceREF.InvoiceNumber,
                            CurrencyId = invoiceREF.CurrencyId,
                            VendorId = invoiceREF.VendorId,
                            InvoiceAmount = invoiceREF.InvoiceAmount,
                            InvoiceReceivedDate = DateTime.Now,
                            InvoiceDueDate = invoiceREF.InvoiceDueDate,
                            IsActive = true,
                            //vendor = vendor,
                            //currency = currency
                        };
                       

                        _context.Invoices.Add(invoice);
                        _context.SaveChangesAsync();
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
                return BadRequest(ex);
            }
        }

        [HttpPut("{iNumber}")]
        public async Task<ActionResult<Invoice>> UpdateInvoice(int iNumber,[FromBody] InvoiceDto invoiceREF)
        {
            try
            {
                Invoice invoice =await _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefaultAsync();

                if (invoice == null)
                {
                    return NotFound("Invoice not found");
                }

                if(iNumber != invoiceREF.InvoiceNumber)
                {
                    return BadRequest("Invoice number mismatch");
                }
                invoice.InvoiceNumber = invoiceREF.InvoiceNumber;
                invoice.CurrencyId = invoiceREF.CurrencyId;
                invoice.VendorId = invoiceREF.VendorId;
                invoice.InvoiceAmount = invoiceREF.InvoiceAmount;
                invoice.InvoiceDueDate = invoiceREF.InvoiceDueDate;
                invoice.IsActive = invoiceREF.IsActive;
                //_context.Entry(invoice).State = EntityState.Modified;

                _context.Invoices.Update(invoice);
                _context.SaveChangesAsync();
                IObservable<string> stringObservable = Observable.Return("Invoice updated");
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{iNumber}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int iNumber)
        {
            Invoice invoiceREF =await _context.Invoices.Where(c => c.InvoiceNumber == iNumber).SingleOrDefaultAsync();
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
