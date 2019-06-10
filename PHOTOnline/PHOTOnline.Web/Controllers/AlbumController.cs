using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.AlbumManagement;
using PHOTOnline.Business.AlbumManagement.Input;
using PHOTOnline.Services.Repositories.Albums;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class AlbumController : Controller
    {
        private IAlbumRepository _albumRepository;
        private IAlbumManager _albumManager;

        public AlbumController(
            IAlbumRepository albumRepository,
            IAlbumManager albumManager)
        {
            _albumRepository = albumRepository;
            _albumManager = albumManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbum(string id)
        {
            Album album = await _albumRepository.FindAsync(id);

            if (album == null) return BadRequest(new Result() { Success = false });
            else return Ok(new Result<Album>() { Success = true, Data = album });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAlbum(string id)
        {
            Result result = await _albumManager.DeleteAlbum(id);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromForm]AddAlbumInput input)
        {
            Result<string> result = await _albumManager.AddAlbum(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            return Ok(new Result<List<Album>>()
            {
                Success = true,
                Data = await _albumRepository.GetAllAlbums()
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbumByPassword(string password)
        {
            Album album = await _albumRepository.GetAlbumByPassword(password);
            if (album != null)
            {
                return Ok(new Result<Album>()
                {
                    Success = true,
                    Data = album
                });
            }
            else
            {
                return BadRequest(new Result<Album>()
                {
                    Success = false
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddImagesToAlbum(
            [FromForm]AddImagesToAlbumInput input)
        {
            Result result = await _albumManager.AddImagesToAlbum(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }
    }
}