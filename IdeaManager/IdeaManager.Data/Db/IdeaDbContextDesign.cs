using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContextDesign : IDesignTimeDbContextFactory<IdeaDbContext>
    {
        public IdeaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdeaDbContext>();
            optionsBuilder.UseSqlite("Data Source=ideaManager.db");
            return new IdeaDbContext();
        }
    }
}
