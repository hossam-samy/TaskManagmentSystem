using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.EF.Repos
{
    public class BaseRepo<T>:IBaseRepo<T>where T : class
    {
        protected AppDbContext dbContext;

        public BaseRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T item)
        {
            
            dbContext.Set<T>().Remove(item);
            dbContext.SaveChanges();
        }

        public IEnumerable<TResult> Get<TResult>(Func<T, bool> match, Func<T, TResult> selector )
        {
            return dbContext.Set<T>().Where(match).Select(selector);
        }
        public IEnumerable<TResult> Get<TResult>( Func<T, TResult> selector)
        {
            return dbContext.Set<T>().Select(selector);
        }
        public IEnumerable<TResult> Get<TResult>(Func<T, TResult> selector,string include)
        {
            return dbContext.Set<T>().Include(include).Select(selector);
        }

        public IEnumerable<T> Get(Func<T, bool> match)
        {
             return dbContext.Set<T>().Where(match);
        }
        public IEnumerable<T> Get(Func<T, bool> match, string[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            if(includes is not null)
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            return query.Where(match);
        }

        public async Task<List<T>> GetAll()
        {
           return dbContext.Set<T>().ToList();
        }

        public async Task<T> Update(T item)
        {
            dbContext.Set<T>().Update(item);
            dbContext.SaveChanges();    
            return item;
        }
    }
}
