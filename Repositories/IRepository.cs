using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Repositories
{
    public interface IRepository<T> where T : class
    {
        //Task<IEnumerable<T>> GetAllasync();
        IEnumerable<T> GetAllasync();
        //Task<T> Authenticate(string username, string password);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
