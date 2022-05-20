using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Repositories
{
    public class TransactionEFRepository : IRepository<Transaction>
    {
        private readonly FinancialAppContext _context;

        public TransactionEFRepository(FinancialAppContext context)
        {
            _context = context;
        }
        public Transaction Add(Transaction entity)
        {
            var entry = _context.Transactions.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Transaction Delete(Transaction entity)
        {
            var entry = _context.Transactions.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Transaction> Get()
        {
            return _context.Transactions;
        }

        public Transaction Get(int id)
        {
            return _context.Transactions.SingleOrDefault(x => x.Id == id);
        }

        public Transaction Update(Transaction entity)
        {
            var entry = _context.Transactions.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
