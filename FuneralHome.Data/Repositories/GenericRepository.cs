using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(DbContext context)
        {
            _ctx = context;
            _DbSet = context.Set<T>();
        }
        public T Create(T model)
        {
            _DbSet.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public bool DeleteById(object id)
        {
            try
            {
                T entity = _DbSet.Find(id);

                _DbSet.Remove(entity);
                _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.AsNoTracking().ToList();
        }

        public T GetById(object id)
        {
            return _DbSet.Find(id);
        }

        public T Update(T model)
        {
            var modelToUpdateProp = model.GetType()
                .GetProperties()
                .FirstOrDefault(x => x.Name == "Id");
            var modelToUpdate = modelToUpdateProp.GetValue(model);
            var updateModel = _DbSet.Find(modelToUpdate);

            _ctx.Entry(updateModel).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return model;

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().Where(predicate).ToList();
        }


    }

}
