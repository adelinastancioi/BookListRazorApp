using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookListRazor.Models
{
    public partial class BookListRazorContext : DbContext
    {
        public BookListRazorContext()
        {
        }

        public BookListRazorContext(DbContextOptions<BookListRazorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4HB514U\\SQLExpress;Database=BookListRazor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Cart__BookId__36B12243");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Review1)
                    .HasColumnName("Review")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Review__BookId__239E4DCF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
