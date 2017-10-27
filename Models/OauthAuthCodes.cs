﻿using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class OauthAuthCodes
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public string Scopes { get; set; }
        public byte Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
