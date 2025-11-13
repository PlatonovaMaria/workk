using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Sales
    {
        public string salesManager {get; private set;}
        public decimal price { get; private set; }
        public string comment { get; private set; }
        public decimal bonus { get; set; }

        public Sales (string _manager, decimal _price, string _comment)
        {
            salesManager = _manager;
            price = _price;
            comment = _comment;
            bonus = _price * 0.01m;
        }
    }
}
