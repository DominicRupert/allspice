using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice.Models;
using spice.Services;


namespace spice.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    public class RecipiesController : ControllerBase
    {
        private readonly RecipiesService _rs;
        private readonly IngredientsService _iserv;
        private readonly StepsService _ss;
        private readonly FavoritesService _fserv;
        public RecipiesController(RecipiesService rs, IngredientsService iserv, StepsService ss, FavoritesService fserv)
        {
            _rs = rs;
            _iserv = iserv;
            _ss = ss;
            _fserv = fserv;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipie>>> GetAllRecipies(string query = "")
        {

            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Recipie> recipies = _rs.GetAllRecipies(userInfo.Id);
                return Ok(recipies);

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipie>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Recipie recipie = _rs.GetById(id, userInfo.Id);
                return Ok(recipie);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/ingredients")]
        public async Task<ActionResult<List<Ingredient>>> GetIngredientsByRecipieId(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Ingredient> ingredients = _iserv.GetByRecipieId(id, userInfo.Id);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/steps")]
        public async Task<ActionResult<List<Step>>> GetStepsByRecipieId(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Step> steps = _ss.GetByRecipieId(id, userInfo.Id);
                return Ok(steps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/favorites")]
        public async Task<ActionResult<List<Favorite>>> GetFavorites(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Favorite> favorites = _fserv.GetByRecipieId(id, userInfo.Id);
                return Ok(favorites);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipie>> CreateAsync([FromBody] Recipie recipieData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                recipieData.CreatorId = userInfo.Id;
                Recipie newRecipie = _rs.CreateRecipie(recipieData);
                newRecipie.Creator = userInfo;
                newRecipie.CreatedAt = new DateTime();
                newRecipie.UpdatedAt = new DateTime();

                return Ok(newRecipie);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipie>> EditAsync([FromBody] Recipie recipieData, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                recipieData.Id = id;
                Recipie updatedRecipie = _rs.Edit(recipieData);


                return Ok(updatedRecipie);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}