using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DebtRepository
    {
        static List<Debt> Debts;
        static List<Bank> Banks;
        static List<Person> People;
        static DebtRepository()
        {
            People = new List<Person>();
            People.Add(new Person()
            {
                IDPerson = 20,
                Name = "Fake1"
            });

            People.Add(new Person()
            {
                IDPerson = 5,
                Name = "Fake2"
            });
            People.Add(new Person()
            {
                IDPerson = 7,
                Name = "Fake3"
            });

            People.Add(new Person()
            {
                IDPerson = 70,
                Name = "Fake5"
            });

            Banks = new List<Bank>();
            Banks.Add(
                new Bank()
                {
                    IDBank = 1,
                    Name = "ING",
                    MaxDebt=1500
                });
            Banks.Add(
                new Bank()
                {
                    IDBank = 10,
                    Name = "BT",
                    MaxDebt=400

                });
            Debts = new List<Debt>();

            Debts.Add( new Debt()
            {
                person = People.First(it=>it.IDPerson==20),
                bank = Banks.First(it=>it.IDBank==1),
                Amount=400

            });
            Debts.Add(new Debt()
            {
                person = People.First(it => it.IDPerson == 20),
                bank = Banks.First(it => it.IDBank == 10),
                Amount = 300

            });

            Debts.Add(new Debt()
            {
                person = People.First(it => it.IDPerson == 5),
                bank = Banks.First(it => it.IDBank == 1),
                Amount = 450

            });
            Debts.Add(new Debt()
            {
                person = People.First(it => it.IDPerson == 7),
                bank = Banks.First(it => it.IDBank == 10),
                Amount = 200

            });

            Debts.Add(new Debt()
            {
                person = People.First(it => it.IDPerson == 70),
                bank = Banks.First(it => it.IDBank == 10),
                Amount = 0

            });

        }

        public async Task<IEnumerable<Bank>> AllBanks()
        {
            await Task.Delay(100);//simulate database delay
            return Banks;

        }
        public async Task<IEnumerable<Person>> AllPersons()
        {
            await Task.Delay(100); ;//simulate database delay
            return People;

        }
        public async Task<IEnumerable<Debt>> DebtsForPeopleAndBanks()
        {
            await Task.Delay(100); ;//simulate database delay
            return Debts;

        }
    }
}
