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
         T Gets(int id);

        public IEnumerable<TResult> Get<TResult>(Func<T,bool>match=null, Func<T, TResult> selector=null );

        public void Register(T InputDto);
        


    }
}
