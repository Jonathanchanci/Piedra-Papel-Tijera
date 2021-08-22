using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class GamePPTContext : DbContext
    {
        public GamePPTContext()
        {
        }

        public GamePPTContext(DbContextOptions<GamePPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batalla> Batallas { get; set; }
        public virtual DbSet<Jugador> Jugadors { get; set; }
        public virtual DbSet<JugadorBatalla> JugadorBatallas { get; set; }
        public virtual DbSet<JugadorBatallaRondum> JugadorBatallaRonda { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<ResultadoBatallaRondum> ResultadoBatallaRonda { get; set; }
        public virtual DbSet<Rondum> Ronda { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E6RV0JV;Database=GamePPT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Batalla>(entity =>
            {
                entity.HasKey(e => e.IdBatalla)
                    .HasName("PK__Batalla__EFEC8462D4628974");

                entity.ToTable("Batalla");

                entity.Property(e => e.IdBatalla).HasColumnName("ID_Batalla");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador)
                    .HasName("PK__Jugador__D7FCF71F1D9BDE22");

                entity.ToTable("Jugador");

                entity.Property(e => e.IdJugador).HasColumnName("ID_Jugador");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<JugadorBatalla>(entity =>
            {
                entity.HasKey(e => e.IdJugadorBatalla)
                    .HasName("PK__JugadorB__25EB38A368E6B034");

                entity.ToTable("JugadorBatalla");

                entity.Property(e => e.IdJugadorBatalla).HasColumnName("ID_JugadorBatalla");

                entity.Property(e => e.FkIdBatalla).HasColumnName("FK_ID_Batalla");

                entity.Property(e => e.FkIdJugador).HasColumnName("FK_ID_Jugador");

                entity.HasOne(d => d.FkIdBatallaNavigation)
                    .WithMany(p => p.JugadorBatallas)
                    .HasForeignKey(d => d.FkIdBatalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JugadorBa__FK_ID__3C69FB99");

                entity.HasOne(d => d.FkIdJugadorNavigation)
                    .WithMany(p => p.JugadorBatallas)
                    .HasForeignKey(d => d.FkIdJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JugadorBa__FK_ID__3D5E1FD2");
            });

            modelBuilder.Entity<JugadorBatallaRondum>(entity =>
            {
                entity.HasKey(e => e.IdJugadorBatallaRonda)
                    .HasName("PK__JugadorB__376AAD97FF602D17");

                entity.Property(e => e.IdJugadorBatallaRonda).HasColumnName("ID_JugadorBatallaRonda");

                entity.Property(e => e.FkIdJugadorBatalla).HasColumnName("FK_ID_JugadorBatalla");

                entity.Property(e => e.FkIdResultadoBatallaRonda).HasColumnName("FK_ID_ResultadoBatallaRonda");

                entity.Property(e => e.FkIdRonda).HasColumnName("FK_ID_Ronda");

                entity.HasOne(d => d.FkIdJugadorBatallaNavigation)
                    .WithMany(p => p.JugadorBatallaRonda)
                    .HasForeignKey(d => d.FkIdJugadorBatalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JugadorBa__FK_ID__440B1D61");

                entity.HasOne(d => d.FkIdResultadoBatallaRondaNavigation)
                    .WithMany(p => p.JugadorBatallaRonda)
                    .HasForeignKey(d => d.FkIdResultadoBatallaRonda)
                    .HasConstraintName("FK__JugadorBa__FK_ID__45F365D3");

                entity.HasOne(d => d.FkIdRondaNavigation)
                    .WithMany(p => p.JugadorBatallaRonda)
                    .HasForeignKey(d => d.FkIdRonda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JugadorBa__FK_ID__44FF419A");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento)
                    .HasName("PK__Movimien__4CD6FF741149CB0D");

                entity.ToTable("Movimiento");

                entity.Property(e => e.IdMovimiento).HasColumnName("ID_Movimiento");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<ResultadoBatallaRondum>(entity =>
            {
                entity.HasKey(e => e.IdResultadoBatallaRonda)
                    .HasName("PK__Resultad__726B97D9A05047A0");

                entity.Property(e => e.IdResultadoBatallaRonda).HasColumnName("ID_ResultadoBatallaRonda");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<Rondum>(entity =>
            {
                entity.HasKey(e => e.IdRonda)
                    .HasName("PK__Ronda__2E6F6171782EF05D");

                entity.Property(e => e.IdRonda).HasColumnName("ID_Ronda");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK__Turno__9FCE7EC7AC8269F1");

                entity.ToTable("Turno");

                entity.Property(e => e.IdTurno).HasColumnName("ID_Turno");

                entity.Property(e => e.FkIdJugadorBatallaRonda).HasColumnName("FK_ID_JugadorBatallaRonda");

                entity.Property(e => e.FkIdMovimiento).HasColumnName("FK_ID_Movimiento");

                entity.HasOne(d => d.FkIdJugadorBatallaRondaNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.FkIdJugadorBatallaRonda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Turno__FK_ID_Jug__4AB81AF0");

                entity.HasOne(d => d.FkIdMovimientoNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.FkIdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Turno__FK_ID_Mov__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
