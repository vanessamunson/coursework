using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class CreatePostRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Body { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
