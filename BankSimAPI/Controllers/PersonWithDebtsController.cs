using BankSimAPI.DTOs;
using DAL;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonWithDebtsController:ControllerBase {
        private readonly ILoansOperationsRepository _repo;
        public PersonWithDebtsController(ILoansOperationsRepository repo) {
            _repo = repo;
        }


        [HttpGet]
        public IEnumerable<Person> GetPersonsWithMultipleDebts() {
            return _repo.RetrieveListOfPersonsWithMultipleDebts();
        }


        [HttpGet("{personId}",Name ="PersonsAndDebts")]
        public PersonWithDebt GetPersonAndDebts(int personId) {
            return _repo.RetriveClientWithBankStats(personId);
        }


        [HttpPost("{bankId}/{personId}")]
        public ActionResult TransferPersonsDebtToOneBank(int bankId,int personId) {
            var resonse = _repo.TransferPersonsDebtToOneBank(bankId, personId);
            switch (resonse) {
                case RefinanceResponse.Succes:
                    return RedirectToRoute("PersonsAndDebts", new { personId = personId });
                case RefinanceResponse.BadRequest:
                    return BadRequest("Total debt over Max debt amount");
                case RefinanceResponse.NotFound:
                    return NotFound();
                default:
                    return BadRequest("Unhanddled Error");
                    
            }

        }


    }
}
