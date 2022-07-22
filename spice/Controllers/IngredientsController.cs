using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice.Models;
using spice.Services;


namespace spice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _iserv;
        public IngredientsController(IngredientsService iserv)
        {
            _iserv = iserv;
        }

        [HttpGet("{recipieId}/ingredients")]
        public async Task<ActionResult<List<Ingredient>>> GetByRecipieId(int recipieId)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Ingredient> ingredients = _iserv.GetByRecipieId(recipieId, userInfo.Id);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{recipieId}")]
        public async Task<ActionResult<Ingredient>> CreateAsync([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Ingredient ingredient = _iserv.Create(ingredientData, userInfo.Id);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}