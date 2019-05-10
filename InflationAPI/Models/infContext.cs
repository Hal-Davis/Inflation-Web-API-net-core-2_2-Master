using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InflationAPI.Models
{
    public partial class infContext : DbContext
    {
        public infContext()
        {
        }

        public infContext(DbContextOptions<infContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvarageCpi> AvarageCpi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=inf;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AvarageCpi>(entity =>
            {
                entity.HasKey(e => e.Year);

                entity.ToTable("avarageCpi");

                entity.Property(e => e.Year).ValueGeneratedNever();
            });
        }
    }
}
