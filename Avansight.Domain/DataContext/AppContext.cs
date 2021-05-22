using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain.DataContext
{
    public class AppContext : DbContext
    {
        //public AppContext() {  }
        public AppContext(DbContextOptions<AppContext> options): base(options) {  }
        public DbSet<Patient> Patients { get; set; } 
    }
}
