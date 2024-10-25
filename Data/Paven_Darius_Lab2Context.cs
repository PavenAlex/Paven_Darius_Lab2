using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paven_Darius_Lab2.Models;

namespace Paven_Darius_Lab2.Data
{
    public class Paven_Darius_Lab2Context : DbContext
    {
        public Paven_Darius_Lab2Context (DbContextOptions<Paven_Darius_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Paven_Darius_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Paven_Darius_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Paven_Darius_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Paven_Darius_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
