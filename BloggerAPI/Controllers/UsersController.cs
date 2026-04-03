using BloggerAPI.Data;
using BloggerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(BloggerDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByUser(int id)
        {
            var userExists = await context.Users.AnyAsync(u => u.Id == id);

            if (!userExists)
                return NotFound();

            return await context.Posts
                .Where(p => p.UserId == id)
                .ToListAsync();
        }
    }
}
