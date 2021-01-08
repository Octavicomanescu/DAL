using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimAPI.DTOs {
    public class PersonWithDebt {
        public int PersonId { get; set; }

        public string PersonName { get; set; }
        public List<Debt> Debts {get; set;}
    }
}
