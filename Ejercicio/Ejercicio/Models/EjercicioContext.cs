using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Models
{
    public partial class EjercicioContext : DbContext
    {
        public EjercicioContext() { }

        public EjercicioContext(DbContextOptions<EjercicioContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_curso_id");

                entity.ToTable("cursos");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_estudiante_id");

                entity.ToTable("estudiantes");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");
                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");
                entity.Property(e => e.Edad).HasColumnName("edad");
                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genero");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_matricula_id");

                entity.ToTable("matriculas");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CursoId).HasColumnName("cursos_id");
                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");
                entity.Property(e => e.EstudianteId).HasColumnName("estudiantes_id");
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.Curso).WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_matriculas_cursos_id");

                entity.HasOne(d => d.Estudiante).WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_matriculas_estudiantes_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}