using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos.Transaction.Request;
using WebApi.Enums;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController: ControllerBase
    {
        /// <summary>
        /// Truy vấn thông tin các giao dịch
        /// </summary>
        /// <param name="request">Điều kiện tìm kiếm</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTransaction([FromQuery] TransactionRequestDto request)
        {
            var path = string.Format("v1/transaction?{0}", request.GetQueryString().Replace("fromdate", "from.timestamp").Replace("todate", "to.timestamp"));
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

        /// <summary>
        /// Phê duyệt thanh toán
        /// </summary>
        /// <param name="request">Nội dung thanh toán</param>
        /// <returns></returns>
        [HttpPost("/approval")]
        public async Task<IActionResult> ApprovalTransaction([FromBody] TransactionApprovalDto request)
        {
            var path = "v1/transaction/approval";
            var body = JsonConvert.SerializeObject(request);
            var result = await ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.POST, path, null, body);
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
        /// Ủy quyền thực hiện giao dịch
        /// </summary>
        /// <param name="request">Nội dung ủy quyền</param>
        /// <returns></returns>
        [HttpPost("/confirmation")]
        public async Task<IActionResult> ConfirmTransaction([FromBody] TransactionConfirmationDto request)
        {
            var path = "v1/transaction/confirmation";
            var body = JsonConvert.SerializeObject(request);
            var result = await ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.POST, path, null, body);
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
        /// Thực hiện một giao dịch (trạng thái chờ-pending)
        /// </summary>
        /// <param name="request">Nội dung giao dịch</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDto request)
        {
            var path = "v1/transaction";
            var body = JsonConvert.SerializeObject(request);
            var result = await ACBOpenApi.Call<dynamic>(Request.HttpContext, MethodBase.POST, path, null, body);
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
