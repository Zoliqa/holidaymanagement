using DVSE.DAL.HolidayManagement.Entity;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVSE.DAL.HolidayManagement.EF
{
    public class HMContext : EntitiesContext // DbContext // EntitiesContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<HolidayPeriod> HolidayPeriods { get; set; }

        public DbSet<HolidayInformation> HolidayInformations { get; set; }

        public DbSet<LegalHoliday> LegalHolidays { get; set; }

        public DbSet<Purpose> Purposes { get; set; }

        public HMContext()
            : base("HolidayManagementDb")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Entity<Request>()
                .HasOptional(x => x.HolidayPeriod)
                .WithMany()
                .HasForeignKey(x => x.HolidayPeriodId);

            modelBuilder
                .Entity<HolidayPeriod>()
                .HasOptional(x => x.Request)
                .WithMany()
                .HasForeignKey(x => x.RequestId);
        }
    }
}
