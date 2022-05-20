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
    public class AccountEFRepository : IRepository<Account>
    {
        private readonly FinancialAppContext _context;

        public AccountEFRepository(FinancialAppContext context)
        {
            _context = context;
        }

        public Account Add(Account entity)
        {
            var entry = _context.Accounts.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Account Delete(Account entity)
        {
            var entry = _context.Accounts.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Account> Get()
        {      
            System.Console.WriteLine("hello");
            return _context.Accounts;
        }

        public Account Get(int id)
        {
            System.Console.WriteLine("hello");
            return _context.Accounts.SingleOrDefault(x => x.Id == id);
        }

        public Account Update(Account entity)
        {
            var entry = _context.Accounts.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
