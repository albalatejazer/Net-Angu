using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]//localhost:5001/api/members
    [ApiController]
    //injext the appdbcontext that was set at program.cs to connect to the db
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        // To return http result
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = context.Users.ToListAsync();

            return await members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMemberById(string id)
        {
            var members = await context.Users.FindAsync(id);
            if (members == null) return NotFound();

            return members;   
        }

    }
}
