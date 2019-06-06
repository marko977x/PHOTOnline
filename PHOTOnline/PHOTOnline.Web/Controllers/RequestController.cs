using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.RequestManagement;
using PHOTOnline.Business.RequestManagement.Input;
using PHOTOnline.Services.Repositories.Requests;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private IRequestManager _requestManager;
        private IRequestRepository _requestRepository;

        public RequestController(
            IRequestManager requestManager,
            IRequestRepository requestRepository)
        {
            _requestManager = requestManager;
            _requestRepository = requestRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromForm]CreateRequestInput input)
        {
            Result<string> result = await _requestManager.CreateRequest(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            return Ok(new Result<List<Request>>()
            {
                Success = true,
                Data = await _requestRepository.GetAllRequests()
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestsByUserId(string id)
        {
            return Ok(new Result<List<Request>>()
            {
                Success = true,
                Data = await _requestRepository.GetRequestsByUserId(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRequest(string id)
        {
            await _requestRepository.DeleteAsync(id);
            return Ok(new Result() { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteResolvedRequests()
        {
            await _requestRepository.DeleteResolvedRequests();
            return Ok(new Result() { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest([FromForm]RejectRequestInput input)
        {
            Result result = await _requestManager.RejectRequest(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }
    }
}