using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q1.Models
{
	public partial class PE_PRN_24FallB1Context : DbContext
	{
		public PE_PRN_24FallB1Context()
		{
		}

		public PE_PRN_24FallB1Context(DbContextOptions<PE_PRN_24FallB1Context> options)
			: base(options)
		{
		}

		public virtual DbSet<Author> Authors { get; set; } = null!;
		public virtual DbSet<Book> Books { get; set; } = null!;
		public virtual DbSet<BookCopy> BookCopies { get; set; } = null!;
		public virtual DbSet<BorrowTransaction> BorrowTransactions { get; set; } = null!;
		public virtual DbSet<User> Users { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
							   .SetBasePath(Directory.GetCurrentDirectory())
							   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfigurationRoot configuration = builder.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>(entity =>
			{
				entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

				entity.Property(e => e.Name).HasMaxLength(255);
			});

			modelBuilder.Entity<Book>(entity =>
			{
				entity.Property(e => e.BookId).HasColumnName("BookID");

				entity.Property(e => e.Publisher).HasMaxLength(255);

				entity.Property(e => e.Title).HasMaxLength(255);

				entity.HasMany(d => d.Authors)
					.WithMany(p => p.Books)
					.UsingEntity<Dictionary<string, object>>(
						"BookAuthor",
						l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BookAuthors_Authors"),
						r => r.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BookAuthors_Books"),
						j =>
						{
							j.HasKey("BookId", "AuthorId").HasName("PK__BookAuth__6AED6DE665F3DA88");

							j.ToTable("BookAuthors");

							j.IndexerProperty<int>("BookId").HasColumnName("BookID");

							j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");
						});
			});

			modelBuilder.Entity<BookCopy>(entity =>
			{
				entity.HasKey(e => e.CopyId)
					.HasName("PK__BookCopi__C26CCCE59E20E782");

				entity.HasIndex(e => e.Isbn, "UQ__BookCopi__447D36EA5AD5B27C")
					.IsUnique();

				entity.Property(e => e.CopyId).HasColumnName("CopyID");

				entity.Property(e => e.BookId).HasColumnName("BookID");

				entity.Property(e => e.Condition).HasMaxLength(255);

				entity.Property(e => e.Isbn)
					.HasMaxLength(13)
					.HasColumnName("ISBN");

				entity.HasOne(d => d.Book)
					.WithMany(p => p.BookCopies)
					.HasForeignKey(d => d.BookId)
					.HasConstraintName("FK_BookCopies_Books");
			});

			modelBuilder.Entity<BorrowTransaction>(entity =>
			{
				entity.HasKey(e => e.TransactionId)
					.HasName("PK__BorrowTr__55433A4B2AFD950C");

				entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

				entity.Property(e => e.BorrowDate).HasColumnType("date");

				entity.Property(e => e.CopyId).HasColumnName("CopyID");

				entity.Property(e => e.ReturnDate).HasColumnType("date");

				entity.Property(e => e.UserId).HasColumnName("UserID");

				entity.HasOne(d => d.Copy)
					.WithMany(p => p.BorrowTransactions)
					.HasForeignKey(d => d.CopyId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_BorrowTransactions_BookCopies");

				entity.HasOne(d => d.User)
					.WithMany(p => p.BorrowTransactions)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_BorrowTransactions_Users");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasIndex(e => e.Email, "UQ__Users__A9D10534608DDE22")
					.IsUnique();

				entity.Property(e => e.UserId).HasColumnName("UserID");

				entity.Property(e => e.Email).HasMaxLength(255);

				entity.Property(e => e.FullName).HasMaxLength(255);

				entity.Property(e => e.MembershipDate).HasColumnType("date");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
