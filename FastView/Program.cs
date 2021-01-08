using DAL;
using System;

namespace FastView
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DebtRepository();
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(d.AllBanks()));
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(d.AllPersons()));
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(d.DebtsForPeopleAndBanks()));

        }
    }
}
