using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enums;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController: ControllerBase
    {
        /// <summary>
        /// Lấy thông tin tài khoản
        /// </summary>
        /// <param name="account_id"></param>
        /// <param name="display_balance"></param>
        /// <returns></returns>
        [HttpGet("/{account_id}")]
        public async Task<IActionResult> GetAccount([FromRoute] string account_id, [FromQuery] bool display_balance)
        {
            var path = string.Format("v1/account/{0}?display_balance={1}", account_id, display_balance);
            var result = await ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.GET, path, null, null);
            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
    }
}
