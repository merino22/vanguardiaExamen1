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
    public class AccountsController : ControllerBase
    {
        private readonly IService<Account> _accountService;

        public AccountsController(IService<Account> accountService)
        {
            _accountService = accountService;
        }

        [HttpGet] // Listado de productos en su tabla
        public ActionResult<IEnumerable<AccountDTO>> Get()
        {
            return Ok(_accountService.Get().Select(x => new AccountDTO
            {
                Id = x.Id,
                Name = x.Name

            }).ToList()
            );
        }

        [HttpPost]
        public ActionResult<AccountDTO> Post([FromBody] AccountDTO newAccount)
        {
            var result = _accountService.Add(new Account
            {
                Id = newAccount.Id
            });
            return result.Success ? Ok(new AccountDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _accountService.Delete(id);
            return result.Success ? Ok(new AccountDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            }) : NotFound("Account no fue encontrado");
        }
    }
}
