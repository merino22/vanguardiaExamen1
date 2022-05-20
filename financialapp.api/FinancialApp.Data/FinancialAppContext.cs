using System;
using FinancialApp.Data.Configurations;
using FinancialApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data
{
    public class FinancialAppContext : DbContext
    {
        public FinancialAppContext(DbContextOptions<FinancialAppContext> options)
            : base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<AccountList> AccountLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
