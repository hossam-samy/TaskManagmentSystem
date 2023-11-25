using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.interfaces
{
    public interface IBaseRepo<T>where T : class
    {

        public IEnumerable<TResult> Get<TResult>(Func<T,bool>match, Func<T, TResult> selector );
        public IEnumerable<TResult> Get<TResult>( Func<T, TResult> selector );
        public IEnumerable<T> Get(Func<T,bool>match );
        public IEnumerable<T> Get(Func<T, bool> match, string[] include);
        public IEnumerable<TResult> Get<TResult>(Func<T, TResult> selector, string include);

        public void Delete(T item); 
        public Task<T> Update( T item );
        public Task<List<T>> GetAll();
        


    }
}
