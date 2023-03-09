using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN221.Model
{
    public partial class PRN221_SP23Context : DbContext
    {
        public PRN221_SP23Context()
        {
        }

        public PRN221_SP23Context(DbContextOptions<PRN221_SP23Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Authur> Authurs { get; set; } = null!;
        public virtual DbSet<CategoryNews> CategoryNews { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("PRN221_SP23"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAccount)
                    .HasName("PK__Account__DA18132CDB6D3C81");

                entity.ToTable("Account");

                entity.Property(e => e.IdAccount).HasColumnName("idAccount");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Authur>(entity =>
            {
                entity.HasKey(e => e.IdAuthur)
                    .HasName("PK__Authur__5EE984AA471AE106");

                entity.ToTable("Authur");

                entity.Property(e => e.IdAuthur).HasColumnName("idAuthur");

                entity.Property(e => e.AuthurName)
                    .HasMaxLength(20)
                    .HasColumnName("authurName");
            });

            modelBuilder.Entity<CategoryNews>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodeConcept)
                    .HasMaxLength(10)
                    .HasColumnName("codeConcept")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.IdImg)
                    .HasName("PK__Image__3C3EAB5AA9BF062E");

                entity.ToTable("Image");

                entity.Property(e => e.IdImg).HasColumnName("idImg");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Image__postId__3F466844");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Post__BE0F4FD6E6F4D851");

                entity.ToTable("Post");

                entity.Property(e => e.IdPost).HasColumnName("idPost");

                entity.Property(e => e.Concept)
                    .HasColumnType("ntext")
                    .HasColumnName("concept");

                entity.Property(e => e.DatePost)
                    .HasColumnType("datetime")
                    .HasColumnName("datePost");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdAuthur).HasColumnName("idAuthur");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.IdAuthurNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdAuthur)
                    .HasConstraintName("FK__Post__idAuthur__3B75D760");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Post__idCategory__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
