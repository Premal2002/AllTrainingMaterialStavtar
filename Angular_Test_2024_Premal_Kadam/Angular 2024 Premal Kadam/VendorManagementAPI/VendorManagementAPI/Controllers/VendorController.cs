using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;


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

        [HttpGet("getVendorByCode/{vCode}")]
        public IActionResult GetVendorByCode(string vCode)
        {
            try
            {
                var v = vendor.GetVendorByCode(vCode);
                return Ok(v);
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
                IObservable<string> stringObservable = Observable.Return(msg);
                return Created("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/Vendor/{vCode}")]
        public IActionResult UpdateVendors(string vCode, [FromBody] Vendor vendorREF)
        {
            try
            {
                var msg = vendor.UpdateVendor(vCode,vendorREF);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{vendorCode}")]
        public IActionResult DeleteVendor(string vendorCode)
        {
            try
            {
                var msg = vendor.DeleteVendor(vendorCode);
                IObservable<string> stringObservable = Observable.Return(msg);
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("export")]
        public IActionResult ExportVendorList()
        {
            try
            {
                var msg = vendor.ExportVendorList();
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


//try
//{

//}
//catch (Exception ex)
//{
//    return NotFound(ex.Message);
//            }