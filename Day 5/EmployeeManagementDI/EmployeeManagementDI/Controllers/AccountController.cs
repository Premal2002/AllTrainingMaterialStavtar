using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Accounts accounts = new Accounts();
        private readonly Accounts _accounts;
        public AccountController(Accounts accountsREF)
        {
            this._accounts = accountsREF;
        }

        [HttpGet("/accounts/list")]
        public IActionResult GetAllAccounts() { 
            var data = _accounts.AllAccounts();
            return Ok(data);
        }

        [HttpGet("/accounts/accid/{accId}")]
        public IActionResult GetAccountsById(int accId)
        {
            try
            {
                var data = _accounts.GetAccountsByAccId(accId);
                return Ok(data);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("accounts/addAccount")]
        public IActionResult AddNewAccount([FromBody] Accounts account)
        {
            try
            {
                string msg = _accounts.AddAccount(account);
                return Created("",msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
