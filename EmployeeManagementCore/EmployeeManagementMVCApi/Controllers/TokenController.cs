﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementMVCApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace EmployeeManagementMVCApi.Controllers
{
    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public TokenController(ApplicationDbContext context, UserManager<IdentityUser> userManger)
        {
            _context = context;
            _userManger = userManger;
        }

        [Route("/Token")]
        [HttpPost]
        public async Task<IActionResult> Create(string username, string password, string grant_type)
        {
            if (await IsValidUserAndPassword(username, password))
            {
                return new ObjectResult(await GenerateToken(username));
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> IsValidUserAndPassword(string username, string password)
        {
            var user = await _userManger.FindByEmailAsync(username);
            return await _userManger.CheckPasswordAsync(user, password);
        }

        private async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userManger.FindByEmailAsync(username);
            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == username
                        select new { ur.UserId, ur.RoleId, r.Name };

            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name,username),
              new Claim(ClaimTypes.NameIdentifier,user.Id),
              new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
              new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var token = new JwtSecurityToken(
                        new JwtHeader(
                        new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyisSecretDoNotTELL ")), SecurityAlgorithms.HmacSha256)),
                        new JwtPayload(claims));


            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };

            return output;


        }


    }
}
