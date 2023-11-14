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
        public T Gets(int id) {
            return dbContext.Set<T>().Find(id);   
           }
       public IEnumerable<TResult> Get<TResult>(Func<T, bool> match, Func<T, TResult> selector)
        {
            return dbContext.Set<T>().Where(match).Select(selector);
         }

       
        void IBaseRepo<T>.Register(T InputDto)
        {

            dbContext.Set<T>().Add(InputDto);
            dbContext.SaveChanges();
        }
        
    }
}
