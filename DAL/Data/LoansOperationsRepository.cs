using BankSimAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Data {
    public class LoansOperationsRepository : ILoansOperationsRepository {
        private readonly DebtRepository _repo;

        public LoansOperationsRepository(DebtRepository repo) {
            _repo = repo;
        }

        public IEnumerable<Person> RetrieveListOfPersonsWithMultipleDebts() {
            var results = _repo.DebtsForPeopleAndBanks().Result.Where(d => d.Amount > 0);
            var personsWithTwoBanks = new List<Person>();


            foreach (var debt in results) {
                var persWithDebt = results.Where(d => d.person.IDPerson == debt.person.IDPerson);
                if (persWithDebt.Count() > 1 && !personsWithTwoBanks.Contains(debt.person)) {
                    personsWithTwoBanks.Add(debt.person);
                }
            }

            return personsWithTwoBanks;
        }

        public PersonWithDebt RetriveClientWithBankStats(int personId) {

            var personFromDB = _repo.AllPersons().Result.Where(p => p.IDPerson == personId).FirstOrDefault();

            var person = new PersonWithDebt() {
                PersonId= personFromDB.IDPerson,
                PersonName= personFromDB.Name,
                Debts=new List<Debt>()
            };

            var debts = _repo.DebtsForPeopleAndBanks().Result.Where(p => p.person.IDPerson == personId);

            person.Debts.AddRange(debts);

            return person;

        }

        public RefinanceResponse TransferPersonsDebtToOneBank(int bankId, int personId) {
            var bankToTransfer = _repo.AllBanks().Result.Where(b => b.IDBank == bankId).FirstOrDefault();
            if (bankToTransfer == null) {
                return RefinanceResponse.NotFound;
            }
            var person = _repo.AllPersons().Result.Where(p => p.IDPerson == personId).FirstOrDefault();
            if (person == null) {
                return RefinanceResponse.NotFound;
            }

            var debts = _repo.DebtsForPeopleAndBanks().Result.Where(d => d.person.IDPerson == personId);
            if (debts.Count() < 2) {
                return RefinanceResponse.BadRequest;
            }

            var maxDebt = bankToTransfer.MaxDebt;
            int sumDebt = 0;
            foreach (var debt in debts) {
                sumDebt += debt.Amount;
            }

            if (sumDebt > maxDebt) {
                return RefinanceResponse.BadRequest;
            }

            foreach (var debt in debts) {
                if (debt.bank.IDBank == bankToTransfer.IDBank) {
                    debt.Amount = sumDebt;
                }
                else {
                    debt.Amount = 0;
                }
            }

            return RefinanceResponse.Succes;
        }
    }
}
