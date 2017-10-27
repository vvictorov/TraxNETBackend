using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class UserFavorites
    {
        public int TrackId { get; set; }
        public int UserId { get; set; }
    }
}
