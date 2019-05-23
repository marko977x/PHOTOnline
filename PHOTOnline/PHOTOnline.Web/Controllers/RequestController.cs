using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.RequestManagement;
using PHOTOnline.Business.RequestManagement.Input;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private IRequestManager _requestManager;

        public RequestController(IRequestManager requestManager)
        {
            _requestManager = requestManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestInput input)
        {
            Result<string> result = await _requestManager.CreateRequest(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {

        }
    }
}