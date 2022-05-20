using FinancialApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Intefaces
{
    public interface IService<T>
    {
        IEnumerable<T> Get();

        Result<T> Get(int id);

        Result<T> Add(T entity);

        Result<T> Update(T entity);

        Result<T> Delete(int id);
    }
}
