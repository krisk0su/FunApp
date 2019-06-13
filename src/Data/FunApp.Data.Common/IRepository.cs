﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunApp.Data.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
