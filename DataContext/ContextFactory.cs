using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class ContextFactory: IContextFactory
    {
        private readonly DbContext context;
        public ContextFactory()
        {
            context = context ?? new Context();
        }

        public DbContext GetContext()
        {
            return context;
        }
    }
}
