using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlazorAPI.Responsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorModel.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserInteraction _userInteraction;
        private readonly IConfiguration _configuration;

        public AccountsController(IUserInteraction userInteraction, IConfiguration configuration)
        {
            _userInteraction = userInteraction;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("auth/register")]
        public async Task<IActionResult> Register([FromBody] Account account)
        {
            try
            {
                var newuser = await _userInteraction.Register(account);
            }
            catch (DbUpdateException)
            {
                if (_userInteraction.FindAccount(account.Username).IsCompletedSuccessfully)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetAccount", new { id = account.Username }, account);
        }

        [HttpPost]
        [Route("auth/login/")]
        public async Task<IActionResult> Post([FromBody]LoginRequest loginRequest)
        {
            var result = await _userInteraction.SignIn(loginRequest);
            if (result == null)
                return BadRequest(new LoginResult { Successful = false, error = "Tài khoản và mật khẩu không đúng" });
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginRequest.username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSecurity"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWTExpiryInDay"]));

            var token = new JwtSecurityToken(
                _configuration["JWTIssuer"],
                _configuration["JWTAudience"],
                claims,
                expires: expiry,
                signingCredentials: cred
                );

            return Ok(new LoginResult { Successful = true, token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(string username, Account account)
        {
            if (username != account.Username)
            {
                return BadRequest();
            }

            try
            {
                await _userInteraction.Update(account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userInteraction.FindAccount(username).IsFaulted)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2

        // DELETE: api/Accounts/5
    }
}