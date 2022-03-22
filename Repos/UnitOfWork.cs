using DataContext;
using Models;
using System;
using System.Data.Entity;

namespace Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext context;
        IModelRepo<Student> repo;
        UserRepo UserRepo;
        public UnitOfWork(IContextFactory _context , IModelRepo<Student> _repo , UserRepo _userRepo)
        {
            context = _context.GetContext();
            repo = _repo;
            UserRepo = _userRepo;
        }
        public IModelRepo<Student> GetRepo()
        {
            return repo;
        }
        public UserRepo GetUserRepo()
        {
            return UserRepo;
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
