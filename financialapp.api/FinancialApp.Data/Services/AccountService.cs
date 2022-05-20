using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using FinancialApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Services
{
    public class AccountService : IService<Account>
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> Get()
        {
            return _accountRepository.Get();
        }

        public Result<Account> Add(Account entity)
        {
            //validar que no exista el nombre del account
            if (_accountRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<Account>($"Account {entity.Name} ya existe");
            }
            var entry = _accountRepository.Add(entity);
            return new Result<Account>(entry);
        }

        public Result<Account> Delete(int id)
        {
            var entity = _accountRepository.Get(id);
            if (entity == null)
            {
                return new Result<Account>($"Account {id} no existe");
            }
            return new Result<Account>(_accountRepository.Delete(entity));
        }

        public Result<Account> Update(Account entity)
        {
            var account = _accountRepository.Get((int)entity.Id);
            if (account == null)
            {
                return new Result<Account>($"Account {entity.Name} no existe");
            }
            return new Result<Account>(_accountRepository.Update(entity));
        }

        public Result<Account> Get(int id)
        {
            var account = _accountRepository.Get(id);
            if (account == null) // si el transaction no existia, lo agrega a la tabla
            {
                account = new Account
                {
                    Id = id
                };
                account = _accountRepository.Add(account);
            }
            return new Result<Account>(account);
        }
    }
}
