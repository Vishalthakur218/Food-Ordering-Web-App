using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealMonkey.Models
{
    public class OrderRes
    {
        public string OrderNo { get; set; }
        public int Quantity { get; set; }
        public int Count { get; set; }
        public int PaymentId { get; set; }
        public string Status { get; set; }
        //public int Amount { get; set; }
        //List<OrderRes> ListOrders = new List<OrderRes>();
    }
}
