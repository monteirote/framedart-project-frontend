using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framedart_project_frontend.Models.Order {
    public class OrderRequestModel {
        public string Reference { get; set; }
        public string Priority { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public List<FramedArtworkModel> FramedArtworks { get; set; }
    }
}
