using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NTechECommerceAPI.EFModels
{
    public partial class NTECommerceDBContext : DbContext
    {
        public NTECommerceDBContext()
        {
        }

        public NTECommerceDBContext(DbContextOptions<NTECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-HARSHA\\SQLEXPRESS;Database=NTECommerceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "UQ__Customer__49A147407428E8D8")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38BF900D6F")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Orders__CreatedB__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
