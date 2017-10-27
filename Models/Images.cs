using System;
using System.Collections.Generic;

namespace TraxNETBackend.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ImageableId { get; set; }
        public string ImageableType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
