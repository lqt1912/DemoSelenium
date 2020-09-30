using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoSelenium.Models
{
    public partial class DemoSeleniumContext : DbContext
    {
        public DemoSeleniumContext()
        {
        }

        public DemoSeleniumContext(DbContextOptions<DemoSeleniumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HN4A59E\\SQLEXPRESS;Initial Catalog=DemoSelenium;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
