using BloggerAPI.Services;
using Db;
using Entities;
using Implementation;
using Interfaces;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloggerAPI.CustomAttributes;

namespace BloggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger _logger;

        public PostsController(IPostService postService, ILogger<PostsController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet]
        public List<Post> Get()
        {
            return _postService.GetAll();
        }

        [HttpGet("{id}")]
        public Post GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting post with ID {PostId}", id);
                return _postService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting post with ID {PostId}", id);
                return null;
            }

        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] CreatePostRequest request)
        {
            try
            {
                _logger.LogInformation("Creating a new post with title {PostTitle}", request.Title);
                _postService.Add(request);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new post with title {PostTitle}", request.Title);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post post)
        {
            try
            {
                _logger.LogInformation("Updating post with ID {PostId}", id);
                if (id != post.Id)
                {
                    _logger.LogWarning("Post ID in the URL does not match the post ID in the body");
                    return;
                }
                _postService.Update(id, post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating post with ID {PostId}", id);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting post with ID {PostId}", id);
                _postService.DeleteById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting post with ID {PostId}", id);
            }
        }
    }
}
