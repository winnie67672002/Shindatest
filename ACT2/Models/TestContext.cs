using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACT2.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActiveItem> TblActiveItems { get; set; } = null!;
        public virtual DbSet<TblSignup> TblSignups { get; set; } = null!;
        public virtual DbSet<TblSignupItem> TblSignupItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-O61HUUI5\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActiveItem>(entity =>
            {
                entity.HasKey(e => e.CItemId)
                    .HasName("PK_TblActiveItem1");

                entity.ToTable("TblActiveItem");

                entity.Property(e => e.CItemId).HasColumnName("cItemID");

                entity.Property(e => e.ActiveDt).HasColumnType("datetime");

                entity.Property(e => e.CItemName)
                    .HasMaxLength(50)
                    .HasColumnName("cItemName");
            });

            modelBuilder.Entity<TblSignup>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("TblSignup");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CCreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("cCreateDT");

                entity.Property(e => e.CEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cEmail");

                entity.Property(e => e.CMobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cMobile");

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName");
            });

            modelBuilder.Entity<TblSignupItem>(entity =>
            {
                entity.HasKey(e => new { e.CSignupId, e.CItemId });

                entity.ToTable("TblSignupItem");

                entity.Property(e => e.CSignupId).HasColumnName("cSignupID");

                entity.Property(e => e.CItemId).HasColumnName("cItemID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
