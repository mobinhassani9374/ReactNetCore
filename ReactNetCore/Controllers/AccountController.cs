using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReactNetCore.Data;

namespace ReactNetCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [AllowAnonymous()]
        [Route("login")]
        public IActionResult Login([FromBody]Models.LoginModel model)
        {
            var user = _context.Users
                  .FirstOrDefault(c => c.UserName.Equals(model.UserName) & c.Password.Equals(model.Password));

            if (user == null)
            {
                return Ok(new Models.LoginResponseModel
                {
                    IsSuccess = false,
                    Message = "کاربری با این مشخصات یافت نشد"
                });
            }
            else
            {
                return Ok(new Models.LoginResponseModel
                {
                    IsSuccess = true,
                    Message = "دریافت توکن",
                    Token = GenerateJSONWebToken(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,user.UserName)
                    })
                });
            }
        }


        private string GenerateJSONWebToken(List<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mobinmahdi.ir/SecrectKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("mobinmahdi.ir",
              "mobinmahdi.ir",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}