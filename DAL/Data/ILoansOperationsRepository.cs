using BankSimAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data {
    public interface ILoansOperationsRepository {
        IEnumerable<Person> RetrieveListOfPersonsWithMultipleDebts();
        RefinanceResponse TransferPersonsDebtToOneBank(int bankId, int personId);

        PersonWithDebt RetriveClientWithBankStats(int personId);
    }
}
