using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class PasswordResets
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
