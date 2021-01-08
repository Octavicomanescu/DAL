using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimAPI.DTOs {
    public class BankWithClients {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public List<Person> Clients { get; set; }
    }
}
