using System;
using System.Collections.Generic;

using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice.Models;
using spice.Services;



namespace spice.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]

    public class FavoritesController:ControllerBase
    {
        private readonly FavoritesService _fserv;
        public FavoritesController(FavoritesService fserv)
        {
            _fserv = fserv;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> CreateAsync([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                favoriteData.CreatorId = userInfo.Id;
                Favorite favorite = _fserv.Create(favoriteData);
                favorite.Creator = userInfo;
                return Ok(favorite);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Favorite>>> GetByUserId(string userId)
        {
            try
            {
                List<Favorite> favorites = _fserv.GetByUserId(userId);
                return Ok(favorites);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetByRecipieId(int recipieId, string userId)
        {
            try
            {
                List<Favorite> favorite = _fserv.GetByRecipieId(recipieId, userId);
                return Ok(favorite);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}