using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Intefaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);
    }
}
