using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Data;
using FinancialApp.Data.Entities;
using FinancialApp.Data.Intefaces;
using FinancialApp.Data.Repositories;
using FinancialApp.Data.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<FinancialAppContext>(opt => opt.UseSqlite(connectionString: "Data Source=financial.db")); //para generar la bd

builder.Services.AddScoped<IRepository<Account>, AccountEFRepository>();
builder.Services.AddScoped<IService<Account>, AccountService>();

builder.Services.AddScoped<IRepository<AccountList>, AccountListEFRepository>();
builder.Services.AddScoped<IService<AccountList>, AccountListService>();

builder.Services.AddScoped<IRepository<Transaction>, TransactionEFRepository>();
builder.Services.AddScoped<IService<Transaction>, TransactionService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<FinancialAppContext>();
context.Database.EnsureCreated();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
