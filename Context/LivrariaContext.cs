using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoLivrariaVS2019.Models;

#nullable disable

namespace ProjetoLivrariaVS2019.Context
{
    public partial class LivrariaContext : DbContext
    {
        public LivrariaContext()
        {
        }

        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<LivroAutor> LivroAutors { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<VwLivroAutor> VwLivroAutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.ToTable("Editora");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.ToTable("Livro");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.DataPublicacao).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdEditora)
                    .HasConstraintName("fk_Livro_Editora");
            });

            modelBuilder.Entity<LivroAutor>(entity =>
            {
                entity.ToTable("Livro_Autor");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.LivroAutors)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Autor");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.LivroAutors)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pessoa");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwLivroAutor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwLivroAutor");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEditora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome Editora");

                entity.Property(e => e.NomeLivro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome Livro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
