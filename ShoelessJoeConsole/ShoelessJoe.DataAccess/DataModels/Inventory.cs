using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int FoodId { get; set; }
        public int Quanity { get; set; }
        public string FoodTitle { get; set; }

        public virtual Foods Food { get; set; }
        public virtual Stores Store { get; set; }
    }
}
