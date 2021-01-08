using BankSimAPI.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimAPI.Data {
    public class BankOperationsRepository : IBankOperationsRepository {

        private readonly DebtRepository _repo;

        public BankOperationsRepository(DebtRepository repo) {
            _repo = repo;
        }

        public IEnumerable<BankWithClients> RetrieveAllBanksWithClients() {
            var results = _repo.DebtsForPeopleAndBanks().Result.Where(d => d.Amount > 0);
            var banks = _repo.AllBanks().Result;

            var bankClients = new List<BankWithClients>();
            foreach (var bank in banks) {
                var theBank = new BankWithClients() {
                    BankId = bank.IDBank,
                    BankName = bank.Name,
                    Clients = new List<Person>()
                };
                bankClients.Add(theBank);
            }

            foreach (var item in bankClients) {
                foreach (var debt in results) {
                    if (item.BankId == debt.bank.IDBank) {
                        item.Clients.Add(debt.person);
                    }
                }
            }
            return bankClients;
        }
        

    }
}
