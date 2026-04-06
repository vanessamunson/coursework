using Microsoft.AspNetCore.Mvc;
using Entities;
using Implementation;
using BloggerAPI.CustomAttributes;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [Authorize]
        public List<User> Get()
        {
            return _userService.GetAll();
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetById(id);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.Add(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _userService.Update(id, user);
        }


        // DELETE: api/Users/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteById(id);
        }
    }
}
