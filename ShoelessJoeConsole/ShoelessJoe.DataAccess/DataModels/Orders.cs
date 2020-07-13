using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Orders
    {
        public Orders()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Users Customer { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
