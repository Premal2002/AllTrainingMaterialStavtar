using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;
using VendorManagementAPI.DTO;
using VendorManagementAPI.Models;


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
        public async Task<ActionResult<IEnumerable<Vendor>>> GetAllVendors()
        {
            try
            {
                var vList = await _context.Vendors.Include(x => x.Invoices).ToListAsync();
                return Ok(vList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{pageNo}")]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetPaginatedVendors(int pageNo,int pageSize = 5)
        {
            try
            {
                var count = _context.Vendors.Count();
                var vList = await _context.Vendors.Skip((pageNo -1)*pageSize).Take(pageSize).ToListAsync();
                var result = new 
                { 
                    count = count,
                    vList = vList
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getVendorByCode/{vCode}")]
        public async Task<ActionResult<Vendor>> GetVendorByCode(string vCode)
        {
            try
            {
                Vendor v = await _context.Vendors.Where(c => c.VendorCode == vCode).SingleOrDefaultAsync();
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
        public async Task<ActionResult> AddVendors([FromBody] VendorDto vendorREF)
        {
            try
            {
                if (await _context.Vendors.AnyAsync(c => c.VendorCode == vendorREF.VendorCode))
                {
                    return BadRequest("There is already vendor with same code.");
                }

                Vendor vendor = new Vendor()
                {
                    VendorCode = vendorREF.VendorCode,
                    VendorLongName = vendorREF.VendorLongName,
                    VendorEmail = vendorREF.VendorEmail,
                    VendorPhoneNumber = vendorREF.VendorPhoneNumber,
                    VendorCreatedOn = DateTime.Now,
                    IsActive = true
                };
                _context.Vendors.Add(vendor);
                _context.SaveChangesAsync();
                IObservable<string> stringObservable = Observable.Return("Vendor Added successfully");
                return Created("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("/api/Vendor/{vCode}")]
        public async Task<ActionResult> UpdateVendors(string vCode, [FromBody] VendorDto vendorREF)
        {
            try
            {
                Vendor vendor = await _context.Vendors.Where(c => c.VendorCode == vCode).SingleOrDefaultAsync();

                if (vendor == null)
                {
                    return NotFound("Vendor not found");
                }

                vendor.VendorCode = vendorREF.VendorCode;
                vendor.VendorLongName = vendorREF.VendorLongName;
                vendor.VendorEmail = vendorREF.VendorEmail;
                vendor.IsActive = vendorREF.IsActive;
                vendor.VendorPhoneNumber = vendorREF.VendorPhoneNumber;
                _context.Update(vendor);
                _context.SaveChangesAsync();
                IObservable<string> stringObservable = Observable.Return("Vendor updated");
                return Accepted("", stringObservable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{vendorCode}")]
        public async Task<ActionResult> DeleteVendor(string vendorCode)
        {
            Vendor vendorREF = await _context.Vendors.Where(c => c.VendorCode == vendorCode).SingleOrDefaultAsync();
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


