using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.DAL.EF;
using Forum_Marchuk.DAL.Interfaces;

namespace Forum_Marchuk.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext context;

        public Repository(ApplicationContext Context) => this.context = Context;

        public virtual async Task<T> GetById<TId>(TId id) => await context.Set<T>().FindAsync(id);
        public virtual async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();
        public virtual async Task Create(T item) => await Task.Run(() => context.Set<T>().Add(item));
        public virtual async Task Update(T item) => await Task.Run(() => context.Modified(item));
        public virtual async Task Delete(T item) => await Task.Run(() => context.Set<T>().Remove(item));
        public void Dispose() => context.Dispose();
    }
}
