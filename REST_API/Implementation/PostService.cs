using Db;
using Entities;
using Contracts;
using Interfaces;

namespace BloggerAPI.Services
{
    public class PostService
    {
        private readonly IJwtService _jwtService;
        private readonly BloggerDbContext _context;

        public PostService(BloggerDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                return post;
            }

            return new Entities.Post { };
        }

        public void Add(CreatePostRequest request)
        {
            if (request != null)
            {
                var newPost = new Entities.Post
                {
                    Title = request.Title,
                    Body = request.Body,
                    UserId = request.UserId
                };
                _context.Posts.Add(newPost);
                _context.SaveChanges();

            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public void Update(int id, Post post)
        {
            if (post != null)
            {
                var dbPost = _context.Posts.FirstOrDefault(p => p.Id == id);
                if (dbPost != null)
                {
                    dbPost.Title = post.Title;
                    dbPost.Body = post.Body;
                    dbPost.UserId = post.UserId;
                    _context.Update(dbPost);
                    _context.SaveChanges();
                }
            }
        }

        // DELETE: api/Posts/5
        public void DeleteById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}

