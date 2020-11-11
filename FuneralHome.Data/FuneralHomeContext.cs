using FuneralHome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data
{
    public class FuneralHomeContext : DbContext
    {        
        public FuneralHomeContext() : base("Default")
        {

        }

        public DbSet<FuneralEmployee> FuneralEmployees { get; set; }
        public DbSet<Funeral> Funerals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Funeral
            modelBuilder.Entity<Funeral>()
                .HasRequired(x => x.Client)
                .WithMany(x => x.Funerals)
                .HasForeignKey(x => x.ClientId);

            #endregion

            #region FunrelEmployee
            modelBuilder.Entity<FuneralEmployee>()
                .HasRequired(x => x.Funeral)
                .WithMany(x => x.FuneralEmployees)
                .HasForeignKey(x => x.FuneralId);

            modelBuilder.Entity<FuneralEmployee>()
                .HasRequired(x => x.Employee)
                .WithMany(x => x.FuneralEmployees)
                .HasForeignKey(x => x.EmployeeId);

            modelBuilder.Entity<FuneralEmployee>()
                .Property(x => x.EmployeeId)
                .HasColumnName("Employee_Id");

            modelBuilder.Entity<FuneralEmployee>()
                .Property(x => x.FuneralId)
                .HasColumnName("Funeral_Id");

            modelBuilder.Entity<FuneralEmployee>()
                .ToTable("FuneralEmployees")
                .HasKey(x => new { x.FuneralId, x.EmployeeId });

            #endregion
        }
    }

}
