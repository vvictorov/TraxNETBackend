using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class Tracks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Slug { get; set; }
    }
}
