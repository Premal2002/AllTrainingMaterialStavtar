using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly Vendor vendor;

        public VendorController(Vendor vendorREF)
        {
            this.vendor = vendorREF;
        }

        [HttpGet]
        public IActionResult GetAllVendors()
        {
            try
            {
                var vList = vendor.GetAllVendors();
                return Ok(vList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddVendors([FromBody] Vendor vendorREF)
        {
            try
            {
                var msg = vendor.AddVendor(vendorREF);
                return Created("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/{vCode}")]
        public IActionResult UpdateVendors(string vCode, [FromBody] Vendor vendorREF)
        {
            try
            {
                var msg = vendor.UpdateVendor(vCode,vendorREF);
                return Accepted("", msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/{vendorCode}")]
        public IActionResult DeleteVendor(string vendorCode)
        {
            try
            {
                var msg = vendor.DeleteVendor(vendorCode);
                return Accepted(msg);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("/vendors/export")]
        public IActionResult ExportVendorList()
        {
            try
            {
                var msg = vendor.ExportVendorList();
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}


//try
//{

//}
//catch (Exception ex)
//{
//    return NotFound(ex.Message);
//            }