using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;

namespace SampleappVS
{
    public partial class TESTContext : DbContext
    {
        public TESTContext(DbContextOptions<TESTContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            var connectionString = @"Host=ec2-54-243-201-58.compute-1.amazonaws.com;Port=5432;User Id=tklitwedjtjvnc;Password=Zd-ppobzSqu2oB0xnD9h84Gpa9;Database=daqqaaieu2ah77;sslmode=Require;Trust Server Certificate=true";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("bpchar")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });
        }

        public virtual DbSet<Company> Company { get; set; }
    }
}