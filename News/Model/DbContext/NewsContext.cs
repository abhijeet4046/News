using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace News.Model.DbContext
{
    public class NewsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NewsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
    }
}
