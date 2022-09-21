using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("auth")]
        [Authorize]
        public ActionResult<string> ErrorAuth()
        {
            return "yes";
        }

        [HttpGet("server-error")]
        public ActionResult<string> ErrorInternal()
        {
            var user = _context.Users.Find(-1);
            return user.ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> BadRequest()
        {
            return BadRequest("ur mom");
        }

        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            var user = _context.Users.Find(-1);
            if (user == null) return NotFound();

            return Ok();
        }
    }
}