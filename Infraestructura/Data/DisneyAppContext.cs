using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestructura.Entities
{
    public partial class DisneyAppContext : DbContext
    {
        public DisneyAppContext()
        {
        }

        public DisneyAppContext(DbContextOptions<DisneyAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Personaje> Personajes { get; set; }
        public virtual DbSet<Rodaje> Rodajes { get; set; }
        public virtual DbSet<Seguridad> Seguridades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("idGenero");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.idRodaje).HasColumnName("idRodaje");

                entity.HasOne(d => d.Rodaje)
                    .WithMany(p => p.Generos)
                    .HasForeignKey(d => d.idRodaje)
                    .HasConstraintName("FK_Genero_Rodaje");
            });

            modelBuilder.Entity<Personaje>(entity =>
            {
                entity.ToTable("Personaje");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("idPersonaje");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Historia)
                    .IsUnicode(false)
                    .HasColumnName("historia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.idRodaje).HasColumnName("idRodaje");

                entity.HasOne(d => d.Rodaje)
                    .WithMany(p => p.Personajes)
                    .HasForeignKey(d => d.idRodaje)
                    .HasConstraintName("FK_Personaje_Rodaje");
            });

            modelBuilder.Entity<Rodaje>(entity =>
            {
                entity.ToTable("Rodaje");

                entity.HasKey(e => e.idRodaje);

                entity.Property(e => e.idRodaje).HasColumnName("idRodaje");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.idPersonaje).HasColumnName("idPersonaje");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Personaje)
                    .WithMany(p => p.Rodajes)
                    .HasForeignKey(d => d.idPersonaje)
                    .HasConstraintName("FK_Rodaje_Personaje");
            });

            modelBuilder.Entity<Seguridad>(entity =>
            {
                entity.ToTable("Segruidad");

                entity.HasKey(e => e.idUser);

                entity.Property(e => e.idUser)
                      .HasColumnName("idUser");

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.Property(e => e.email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");
               
            });
            


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
