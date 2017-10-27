using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class OauthPersonalAccessClients
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
