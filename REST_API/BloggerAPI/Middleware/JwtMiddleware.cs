using Interfaces;
namespace BloggerAPI.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    // attach user to context on successful jwt validation
                    context.Items["User"] = userService.GetById(jwtService.GetUserIdFromToken(token));
                }
                catch
                {
                    // do nothing if jwt validation fails
                    // user is not attached to context so request won't have access to secure routes
                }
            }

            await _next(context);
        }

    }
}
