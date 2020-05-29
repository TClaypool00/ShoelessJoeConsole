using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Shoes
    {
        public int ShoeId { get; set; }
        public bool BothShoes { get; set; }
        public string Manufacter { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal? RightSize { get; set; }
        public decimal? LeftSize { get; set; }
        public int? UserId { get; set; }
        public bool IsSold { get; set; }
    }
}
