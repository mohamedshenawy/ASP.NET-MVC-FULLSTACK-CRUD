using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IModelRepo<T>
    {
        void Create(T entity);
        IQueryable<T> Read();
        void Update(T entity);
        void Delete(T entity);
        T GetByID(int id);
    }
}
