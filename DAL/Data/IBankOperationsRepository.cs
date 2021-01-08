using BankSimAPI.DTOs;
using System.Collections.Generic;

namespace BankSimAPI.Data {
    public interface IBankOperationsRepository {
        IEnumerable<BankWithClients> RetrieveAllBanksWithClients();
    }
}
