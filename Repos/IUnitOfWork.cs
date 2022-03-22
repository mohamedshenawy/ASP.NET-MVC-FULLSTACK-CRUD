using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{

    public interface IUnitOfWork
    {
        IModelRepo<Student> GetRepo();
        UserRepo GetUserRepo();
        void Save();
    }
}
