using MealMonkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealMonkey.ViewModel
{
    public class ProdCartViewModel
    {
        public IEnumerable<MM_Carts> Carts { get; set; }
        public IEnumerable<MM_Products> Products { get; set; }
    }
}