using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]//localhost:5001/api/members
    [ApiController]
    //injext the appdbcontext that was set at program.cs to connect to the db
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        // To return http result
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var members = context.Users.ToList();

            return members;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetMemberById(string id)
        {
            var members = context.Users.Find(id); 
            if (members == null) return NotFound();

            return members;
        }

    }
}
