using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Models;

namespace webdev.DataAccessLayer
{
    public class LinksContext : DbContext
    {
        public LinksContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LinkData> LinksData { get; set; }
    }
}
