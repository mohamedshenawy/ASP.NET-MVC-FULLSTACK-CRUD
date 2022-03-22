using DataContext;
using Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Repos
{
    public class ModelRepo<T> : IModelRepo<T> where T: BaseModel
    {
        DbContext context;
        DbSet<T> Table;
        public ModelRepo(IContextFactory _ContextFactory)
        {
            context = _ContextFactory.GetContext();
            Table = context.Set<T>();
        }
        public void Create(T entity)
        {
            Table.Add(entity);  
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            //Table.Remove(GetByID(id));
        }
        public  T GetByID(int id)
        {
            return Table.FirstOrDefault(e => e.ID == id);
        }

        public IQueryable<T> Read()
        {
            return Table;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //var model = GetByID(entity.ID);
            //Table.Remove(model);
            //Table.Add(entity);
        }
    }
}
