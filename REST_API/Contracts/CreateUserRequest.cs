namespace Contracts
{
    public class CreateUserRequest
    {

        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
