using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Marchuk.DAL.Interfaces
{
    public interface IRepository<T>: IDisposable where T : class
    {
            Task<T> GetById<TId>(TId id);
            Task<IEnumerable<T>> GetAll();

            Task Create(T item);
            Task Update(T item);
            Task Delete(T item);
        
    }
}
