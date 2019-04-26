using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ReactNetCore.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous()]
        public IActionResult Login([FromBody]LoginModel model)
        {
            return Ok();
        }
    }
}