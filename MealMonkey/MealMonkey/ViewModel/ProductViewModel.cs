using MealMonkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealMonkey.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<MM_Products> Products { get; set; }
        public IEnumerable<MM_Categories> Categories { get; set; }

    }
}