using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class OauthClients
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Redirect { get; set; }
        public byte PersonalAccessClient { get; set; }
        public byte PasswordClient { get; set; }
        public byte Revoked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
