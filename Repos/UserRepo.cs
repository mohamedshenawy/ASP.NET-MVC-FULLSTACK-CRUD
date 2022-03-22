using DataContext;
using Models;
using System.Data.Entity;
using System.Linq;

namespace Repos
{
    public class UserRepo
    {
        DbContext context;
        DbSet<User> users;
        public UserRepo(IContextFactory _ContextFactory)
        {
            context = _ContextFactory.GetContext();
            users = context.Set<User>();
        }
        public bool LogInCheck(string userName, string password)
        {
            var user = (from u in users
                       where u.Name == userName && u.Password == password
                       select u).FirstOrDefault();
            return user != null;
        }
    }
}
