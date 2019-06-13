using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunApp.Data.Common;
using Microsoft.EntityFrameworkCore;


namespace FunApp.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private FunAppContext context;
        private DbSet<TEntity> dbSet;

        public DbRepository(FunAppContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public Task Add(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

    }
}
