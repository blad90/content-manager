using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentManager.Data
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<Professor> Professors { get; set; }
    }
}
