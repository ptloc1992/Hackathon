using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Dtos.Request.User;
using WebApi.Dtos.User;
using WebApi.Dtos.User.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            formData.Add(new KeyValuePair<string, string>("code", login.Code));
            formData.Add(new KeyValuePair<string, string>("redirect_uri", @"urn:ietf:wg:oauth:2.0:oob"));
            formData.Add(new KeyValuePair<string, string>("client_id", "locpt01"));
            formData.Add(new KeyValuePair<string, string>("client_secret", "c4de55cf-17d2-470d-934c-a97d206ed0e4"));
            var result = await Helpers.ACBOpenApi.Call<LoginDto>(HttpMethod.Post, @"auth/realms/soba/protocol/openid-connect/token", formData, null);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}