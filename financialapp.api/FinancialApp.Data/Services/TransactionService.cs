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
    public class TransactionService : IService<Transaction>
    {
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Result<Transaction> Add(Transaction entity)
        {
            // Validar que no exsta el nombre del transaction
            if (_transactionRepository.Get().Any(x => x.Id == entity.Id))
            {
                return new Result<Transaction>($"Transaction {entity.Id} ya existe");
            }
            var entry = _transactionRepository.Add(entity);
            return new Result<Transaction>(entry);
        }

        public Result<Transaction> Delete(int id)
        {
            var entity = _transactionRepository.Get(id);
            if (entity == null)
            {
                return new Result<Transaction>($"Transaction con ID: {id} no existe");
            }
            return new Result<Transaction>(_transactionRepository.Delete(entity));
        }

        public Result<Transaction> Get(int id)
        {
            var transaction = _transactionRepository.Get(id);
            if (transaction == null) // si el transaction no existia, lo agrega a la tabla
            {
                transaction = new Transaction
                {
                    Id = id
                };
                transaction = _transactionRepository.Add(transaction);
            }
            return new Result<Transaction>(transaction);
        }

        public Result<Transaction> Update(Transaction entity)
        {
            var transaction = _transactionRepository.Get((int)entity.Id);
            if (transaction == null)
            {
                return new Result<Transaction>($"Product {entity.Id} no existe");
            }
            return new Result<Transaction>(_transactionRepository.Update(entity));

        }
        public IEnumerable<Transaction> Get()
        {
            return _transactionRepository.Get();
        }
    }
}
