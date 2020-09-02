using AuditorService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AuditorService.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(AppDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAllasync()
        {
            IEnumerable<T> objEntity = entities.AsEnumerable(); 
            return objEntity;
        }
        

        public int Insert(T entity)
        {
            entities.Add(entity);
            int res = context.SaveChanges();
            return res;
        }
        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.ToString());
            }
            entities.Update(entity);
            int res = context.SaveChanges();
            return res;
        }
        public int Delete(T entity)
        {
            int res = 0;
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            res = context.SaveChanges();
            return res;
        }
    }
}
