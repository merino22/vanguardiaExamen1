using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialApp.API.DataTransferObjects
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        public long AccountId { get; set; }

        public Account Account { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }
    }
}
