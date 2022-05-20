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
    public class AccountListService : IService<AccountList>
    {
        private readonly IRepository<AccountList> _accountListRepository;

        public AccountListService(IRepository<AccountList> accountListRepository)
        {
            _accountListRepository = accountListRepository;
        }

        public Result<AccountList> Add(AccountList entity)
        {
            // validar que no se repita nombre de lista
            if (_accountListRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<AccountList>($"Lista {entity.Name} ya existe");
            }
            var entry = _accountListRepository.Add(entity);
            return new Result<AccountList>(entry);
        }

        public IEnumerable<AccountList> Get()
        {
            return _accountListRepository.Get();
        }

        public Result<AccountList> Update(AccountList entity)
        {
            var list = _accountListRepository.Update(entity);
            return new Result<AccountList>(list);
        }

        public Result<AccountList> Delete(int id)
        {
            var entity = _accountListRepository.Get(id);
            if (entity == null)
            {
                return new Result<AccountList>($"Lista {id} no existe");
            }
            return new Result<AccountList>(_accountListRepository.Delete(entity));
        }

        public Result<AccountList> Get(int id)
        {
            var list = _accountListRepository.Get(id);
            return list == null ? new Result<AccountList>($"La lista con ID: {id} no existe")
                : new Result<AccountList>(list);
        }
    }
}
