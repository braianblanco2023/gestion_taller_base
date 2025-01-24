using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System;
using MySql.EntityFrameworkCore;    
using MySql.Data;                   

namespace TallerAppRazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Talleres> Talleres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //for SQL Server:
            //optionsBuilder.UseSqlServer("/*DB Ref ConnectionString*/");
            // MySQL:
            optionsBuilder.UseMySQL(/*DB Ref ConnectionString*/);
        }
    }
}

