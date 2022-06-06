using HeThongHocTapVaKiemTraTT.Models;
using Microsoft.EntityFrameworkCore;

namespace HeThongHocTapVaKiemTraTT.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountClass> AccountClasses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }
        public DbSet<Semester>  Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountClass>()
                .HasKey(ac => new { ac.AccountId, ac.ClassId });
            modelBuilder.Entity<AccountClass>()
                .HasOne(a => a.Account)
                .WithMany(ac => ac.AccountClasses)
                .HasForeignKey(a => a.AccountId);
            modelBuilder.Entity<AccountClass>()
                .HasOne(c => c.Class)
                .WithMany(ac => ac.AccountClasses)
                .HasForeignKey(c => c.ClassId);
        }
    }
}
