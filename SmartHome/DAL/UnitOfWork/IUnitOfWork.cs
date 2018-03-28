using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IUnitOfWork<T> where T : class
    {
        void RegisterQuery(IQueryable<T> query);
        string ExecuteSelection(IQueryable<T> query);
        void SaveChanges();
    }
}
