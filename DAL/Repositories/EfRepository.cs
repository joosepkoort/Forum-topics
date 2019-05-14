using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        public EfRepository(IAppDataContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(paramName: nameof(dbContext));
            }
            RepositoryDbContext = dbContext as DbContext;
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
            if (RepositoryDbSet == null)
            {
                throw new NullReferenceException(message: nameof(RepositoryDbSet));
            }
        }

        public List<TEntity> All
        {
            get
            {
                var resCount = RepositoryDbSet.Count();
                if (resCount < 20)
                {
                    return RepositoryDbSet.ToList();
                }
                throw new Exception(message: "Too many records in resultset! Please add a custom data access method to repository");
            }
        }

        public TEntity Find(int id)
        {
            return RepositoryDbSet.Find(id);
        }

        public void Remove(int id)
        {
            Remove(entity: Find(id: id));
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity: entity);
        }

        public TEntity Add(TEntity entity)
        {
            return RepositoryDbSet.Add(entity: entity);
        }

        public void Update(TEntity entity)
        {
            RepositoryDbContext.Entry(entity: entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return RepositoryDbContext.SaveChanges();
        }
    }
}
