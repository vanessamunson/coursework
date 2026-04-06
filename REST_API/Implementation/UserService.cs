using Contracts;
using Db;
using Entities;
using Interfaces;

namespace Implementation
{
    public class UserService : IUserService
    {
        private readonly IJwtService _jwtService;
        private readonly BloggerDbContext _context;

        public UserService(IJwtService jwtService, BloggerDbContext context)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return user;
            }

            return new Entities.User { };
        }

        public void Add(User user)
        {
            if (user != null)
            {
                var newUser = new Entities.User 
                { 
                    Username = user.Username, 
                    Password = user.Password, 
                };
                _context.Users.Add(user);
                _context.SaveChanges();

            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public void Update(int id, User user)
        {
            if (user != null)
            {
                var dbUser = _context.Users.FirstOrDefault(u => u.Id == id);
                if (dbUser != null)
                {
                    dbUser.Username = user.Username;
                    dbUser.Password = user.Password;
                    _context.Update(dbUser);
                    _context.SaveChanges();
                }
            }
        }

        // DELETE: api/Users/5
        public void DeleteById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public AuthenticateResponse Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
                return null;
            var token = _jwtService.GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
