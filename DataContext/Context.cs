using Models;
using System;
using System.Data.Entity;

namespace DataContext
{
    public class Context :DbContext
    {

        public Context():base("Data Source=localhost;Initial Catalog=CrudOperations;Integrated Security=True")
        {
        }

        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<User> users { get; set; }
    }
}
