using FinancialApp.API.DataTransferObjects;
using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinancialApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IService<Transaction> _transactionService;

        public TransactionsController(IService<Transaction> transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet] // Listado de productos en su tabla
        public ActionResult<IEnumerable<TransactionDTO>> Get()
        {
            return Ok(_transactionService.Get().Select(x => new TransactionDTO
            {
                Id = x.Id,
            }).ToList()
            );
        }

        [HttpPost]
        public ActionResult<AccountDTO> Post([FromBody] AccountDTO newTransaction)
        {
            var result = _transactionService.Add(new Transaction
            {
                Id = newTransaction.Id
            });
            return result.Success ? Ok(new TransactionDTO
            {
                Id = result.Value.Id,
                Account = result.Value.Account,
                AccountId = result.Value.AccountId,
                Amount = result.Value.Amount,
                Description = result.Value.Description
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _transactionService.Delete(id);
            return result.Success ? Ok(new TransactionDTO
            {
                Id = result.Value.Id,
                Account = result.Value.Account,
                AccountId = result.Value.AccountId,
                Description = result.Value.Description,
                Amount = result.Value.Amount
            }) : NotFound("Account no fue encontrado");
        }
    }
}
