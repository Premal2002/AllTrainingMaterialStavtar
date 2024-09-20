using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;


namespace VendorManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorManagementContext _context;

        public VendorController(VendorManagementContext Context)
        {
            this._context = Context;
        }

        [HttpGet]
        public IActionResult GetAllVendors()
        {
            try
            {
                var vList = _context.Vendors.ToList();
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
                Vendor v = _context.Vendors.Where(c => c.VendorCode == vCode).SingleOrDefault();
                if (v != null)
                    return Ok(v);
                else
                    throw new Exception("Vendor with code " + vCode + " is not present");
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
                if (_context.Vendors.Any(c => c.VendorCode == vendorREF.VendorCode))
                {
                    return BadRequest("There is already vendor with same code.");
                }
                vendorREF.VendorCreatedOn = DateTime.Now;
                _context.Vendors.Add(vendorREF);
                _context.SaveChanges();
                IObservable<string> stringObservable = Observable.Return("Vendor Added successfully");
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
                Vendor vendor = _context.Vendors.Where(c => c.VendorCode == vCode).SingleOrDefault();

                if (vendor == null)
                {
                    return NotFound("Vendor not found");
                }

                vendor.VendorCode = vendorREF.VendorCode;
                vendor.VendorLongName = vendorREF.VendorLongName;
                vendor.VendorEmail = vendorREF.VendorEmail;
                vendor.IsActive = vendorREF.IsActive;
                vendor.VendorPhoneNumber = vendorREF.VendorPhoneNumber;
                _context.Entry(vendor).State = EntityState.Modified;
                _context.SaveChanges();
                IObservable<string> stringObservable = Observable.Return("Vendor updated");
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
            Vendor vendorREF = _context.Vendors.Where(c => c.VendorCode == vendorCode).SingleOrDefault();
            if (vendorREF == null)
            {
                return NotFound("vendor not found");
            }
            else if (_context.Invoices.Any(i => i.VendorId == vendorREF.VendorId))
            {
                return BadRequest("Vendor still has invoices pending!!!.");
            }

            _context.Vendors.Remove(vendorREF);
            _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPost]
        //[Route("export")]
        //public IActionResult ExportVendorList()
        //{
        //    try
        //    {
        //        var msg = vendor.ExportVendorList();
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


//try
//{

//}
//catch (Exception ex)
//{
//    return NotFound(ex.Message);
//            }