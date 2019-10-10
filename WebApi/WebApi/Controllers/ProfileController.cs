using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Dtos.Profile.Request;
using WebApi.Dtos.Request.User;
using WebApi.Dtos.User;
using WebApi.Dtos.User.Response;
using WebApi.Enums;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Truy vấn thông tin chủ tài khoản
        /// </summary>
        /// <param name="detailed">Chi tiết. (true/false)</param>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<IActionResult> GetProfileInfo([FromQuery] bool detailed)
        {
            var path = string.Format("v1/profile/info?detailed={0}", detailed);
            var result = await Helpers.ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.GET, path, null, null);
            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        /// <summary>
        /// Truy vấn thông tin tài khoản ngân hàng
        /// </summary>
        /// <param name="request">Điều kiện tìm kiếm</param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetProfile([FromQuery] ProfileRequestDto request)
        {
            var path = string.Format("v1/profile?{0}", request.GetQueryString());
            var result = await Helpers.ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.GET, path, null, null);
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