using System.Collections.Generic;
using System.Threading.Tasks;
using BloggerAPI.Data;
using BloggerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BloggerDbContext _context;

        public PostsController(BloggerDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            return post;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == post.UserId);

            if (!userExists)
                return BadRequest("Invalid UserId.");

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post updatedPost)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            var userExists = await _context.Users.AnyAsync(u => u.Id == updatedPost.UserId);

            if (!userExists)
                return BadRequest("Invalid UserId.");

            post.Title = updatedPost.Title;
            post.Body = updatedPost.Body;
            post.UserId = updatedPost.UserId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
