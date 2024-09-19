using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reactive.Linq;

namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly Invoice invoice;

        public InvoiceController(Invoice invoiceREF)
        {
            this.invoice = invoiceREF;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            try
            {
                var iList = invoice.GetAllInvoices();
                return Ok(iList);
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
                var i = invoice.GetInvoiceByNumber(iNumber);
                return Ok(i);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{vCode}")]
        public IActionResult GetAllInvoicesByVendorCode(string vCode)
        {
            try
            {
                var iList = invoice.GetInvoicesByVendorCode(vCode);
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
                var iList = invoice.GetInvoiceCountByVendor();
                return Ok(iList);
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
                var msg = invoice.AddInvoice(invoiceREF);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Created("", stringObservable);
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
                var msg = invoice.UpdateInvoice(iNumber,invoiceREF);
                IObservable<string> stringObservable = Observable.Return(msg);
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
            try
            {
                var msg = invoice.DeleteInvoice(iNumber);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Accepted(stringObservable);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("export")]
        public IActionResult ExportInvoiceList()
        {
            try
            {
                var msg = invoice.ExportInvoiceList();
                IObservable<string> stringObservable = Observable.Return(msg);
                return Ok(stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
}
}
