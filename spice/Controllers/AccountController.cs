using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spice.Models;
using spice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace spice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // [HttpGet("{id}/recipies") ]
        // public async Task<ActionResult<List<Favorite>>> GetRecipies(int id)
        // {
        //     try
        //     {
        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        //         List<Recipie> recipies = _accountService.GetRecipies(id, creatorId: userInfo.Id);
        //         return Ok(recipies);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }


}