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
        public RecipiesController(RecipiesService rs , IngredientsService iserv)
        {
            _rs = rs;
            _iserv = iserv;
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
        public async Task<ActionResult<Recipie>> GetRecipie(int id)
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
        public async Task<ActionResult<List<Ingredient>>> GetByRecipieId(int id)
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


    }
}