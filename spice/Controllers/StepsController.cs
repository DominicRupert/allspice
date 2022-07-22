using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice.Models;
using spice.Services;


namespace spice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepsController: ControllerBase
    {
        private readonly StepsService _ss;
        public StepsController(StepsService ss)
        {
            _ss = ss;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Step>>> GetByRecipieId(int recipieId)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Step> steps = _ss.GetByRecipieId(recipieId, userInfo.Id);
                return Ok(steps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Step>> CreateAsync([FromBody] Step stepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Step step = _ss.Create(stepData, userInfo.Id);
                return Ok(step);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}