using BankSimAPI.Data;
using BankSimAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankSimAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase {

        private readonly IBankOperationsRepository _repo;

        public BankController(IBankOperationsRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<BankWithClients> GetBanks() {

            return _repo.RetrieveAllBanksWithClients();
            
        }
    }
}
