using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class AudioFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int TrackId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
