using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail:IEntity
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitePrice { get; set; }
        public short Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
