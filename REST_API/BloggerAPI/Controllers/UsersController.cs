using Microsoft.AspNetCore.Mvc;
using Entities;
using Implementation;
using BloggerAPI.CustomAttributes;
using Interfaces;
using Contracts;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string Role;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UsersController(UserService userService, ILogger<UsersController> Logger)
        {
            _userService = userService;
            _logger = Logger;
        }

        // GET: api/Users
        [Authorize]
        public List<User> Get()
        {
            try
            {
                _logger.LogInformation("Getting all users");
                return _userService.GetAll();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all users");
                return null;
            }
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public User Get(int id)
        {
            try
            {
                _logger.LogInformation($"Getting user with id: {id}");
                return _userService.GetById(id); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user with id: {id}");
                return null;
            }
            
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void Post([FromBody] CreateUserRequest request)
        {
            try
            {
                _logger.LogInformation($"Creating a new user with username: {request.Username}");
                _userService.Add(request);

                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    _logger.LogWarning("Invalid user creation request: Username or Password is null or empty");
                    return;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new user");
                return;
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            try
            {
                _logger.LogInformation($"Updating user with id: {id}");
                if (id != user.Id)
                {
                    _logger.LogWarning($"User ID in the URL ({id}) does not match User ID in the body ({user.Id})");
                    return;
                }
                _userService.Update(id, user);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating user with id: {id}");
                return;
            }
        }


        // DELETE: api/Users/5
        [Authorize(Role = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting user with id: {id}");
                _userService.DeleteById(id);
            }
            catch
            {
                _logger.LogError($"An error occurred while deleting user with id: {id}");
                return;
            }
            
        }
    }
}
