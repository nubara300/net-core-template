using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace MinimalisticAPIExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckPinController : ControllerBase
    {
        [HttpPost]
        public ActionResult<bool> GetSEPerson([FromBody]string pin)
        {
            try
            {
                Regex regex = new(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})");
                return Ok(regex.IsMatch(pin));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
