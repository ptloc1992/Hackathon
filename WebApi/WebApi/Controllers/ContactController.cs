using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos.Contact.Request;
using WebApi.Enums;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController: ControllerBase
    {
        /// <summary>
        /// Lấy toàn bộ danh bạ, thông tin liên lạc
        /// </summary>
        /// <param name="request">Điều kiện tìm kiếm</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetContact([FromQuery] ContactRequestDto request)
        {
            var path = string.Format("v1/contact?{0}", request.GetQueryString());
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
