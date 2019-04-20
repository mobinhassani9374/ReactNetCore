using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReactNetCore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly Data.AppDbContext _context;
        public UserController(Data.AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _context.Users.ToList();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(Data.Entities.User model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}