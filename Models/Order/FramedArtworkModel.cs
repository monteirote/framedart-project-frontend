using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framedart_project_frontend.Models.Order {
    public class FramedArtworkModel {
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Price { get; set; }
        public int? GlassId { get; set; }
        public int? FrameId { get; set; }
        public int? PaperId { get; set; }
        public int? BackgroundId { get; set; }
        public List<string> Images { get; set; } = [];
    }
}
