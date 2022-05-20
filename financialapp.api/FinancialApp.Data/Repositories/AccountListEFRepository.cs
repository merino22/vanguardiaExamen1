using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Repositories
{
    public class AccountListEFRepository : IRepository<AccountList>
    {
        private readonly FinancialAppContext _context;

        public AccountListEFRepository(FinancialAppContext context)
        {
            _context = context;
        }

        public AccountList Add(AccountList entity)
        {
            var entry = _context.AccountLists.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public AccountList Delete(AccountList entity)
        {
            var entry = _context.AccountLists.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<AccountList> Get()
        {
            return _context.AccountLists;
        }

        public AccountList Get(int id)
        {
            return _context.AccountLists.Include(x => x.Accounts).SingleOrDefault(x => x.Id == id);
        }

        public AccountList Update(AccountList entity)
        {
            var entry = _context.AccountLists.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
