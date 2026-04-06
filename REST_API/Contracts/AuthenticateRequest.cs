using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts;

public class AuthenticateRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
