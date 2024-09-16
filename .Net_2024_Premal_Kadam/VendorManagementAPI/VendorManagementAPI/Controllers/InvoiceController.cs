using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/{vCode}")]
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

        [HttpGet("/invoices/countByVendorId")]
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
                return Created("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/{iNumber}")]
        public IActionResult UpdateInvoice(int iNumber,[FromBody] Invoice invoiceREF)
        {
            try
            {
                var msg = invoice.UpdateInvoice(iNumber,invoiceREF);
                return Accepted("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/{iNumber}")]
        public IActionResult DeleteInvoice(int iNumber)
        {
            try
            {
                var msg = invoice.DeleteInvoice(iNumber);
                return Accepted(msg);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("/invoices/export")]
        public IActionResult ExportInvoiceList()
        {
            try
            {
                var msg = invoice.ExportInvoiceList();
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
}
}
