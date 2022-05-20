using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Repositories
{
    public class AccountEFRepository : IRepository<Account>
    {
        private readonly FinancialAppContext _context;

        public AccountEFRepository(FinancialAppContext context)
        {
            _context = context;
        }

        public Account Add(Account entity)
        {
            var entry = _context.Account.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Account Delete(Account entity)
        {
            var entry = _context.Account.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Account> Get()
        {
            return _context.Account;
        }

        public Account Get(int id)
        {
            return _context.Account.SingleOrDefault(x => x.Id == id);
        }

        public Account Update(Account entity)
        {
            var entry = _context.Account.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
