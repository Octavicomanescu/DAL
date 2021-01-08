using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Debt
    {
        public Bank bank { get; set; }
        public Person person { get; set; }
        public int Amount { get; set; }
    }
}
