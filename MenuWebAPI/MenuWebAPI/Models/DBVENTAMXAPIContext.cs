using Microsoft.EntityFrameworkCore;

namespace MenuWebAPI.Models
{
    public class DBVENTAMXAPIContext : DbContext
    {
        public DBVENTAMXAPIContext()
        {
        }

        public DBVENTAMXAPIContext(DbContextOptions<DBVENTAMXAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CStatusRegistro> CStatusRegistros { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolMenu> RolMenus { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Configuracion> Configuraciones { get; set; }
        public virtual DbSet<ColoniaSAT> ColoniaSAT {  get; set; }
        public virtual DbSet<LocalidadSAT> LocalidadesSAT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo CStatusRegistro
            modelBuilder.Entity<CStatusRegistro>(entity =>
            {
                entity.HasKey(e => e.IdStatusRegistro);
                entity.ToTable("c_StatusRegistro");
                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            // Mapeo Menu
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);
                entity.ToTable("Menu");
                entity.Property(e => e.Descripcion).HasMaxLength(100);
                entity.Property(e => e.Icono).HasMaxLength(50);
                entity.Property(e => e.Controlador).HasMaxLength(100);
                entity.Property(e => e.PaginaAccion).HasMaxLength(100);

                entity.HasOne(d => d.IdStatusRegistroNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdStatusRegistro);

                entity.HasOne(d => d.IdMenuPadreNavigation)
                    .WithMany(p => p.InverseIdMenuPadreNavigation)
                    .HasForeignKey(d => d.IdMenuPadre);
            });

            // Mapeo Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);
                entity.ToTable("Rol");
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.HasOne(d => d.IdStatusRegistroNavigation)
                    .WithMany(p => p.Rols)
                    .HasForeignKey(d => d.IdStatusRegistro);
            });

            // Mapeo RolMenu
            modelBuilder.Entity<RolMenu>(entity =>
            {
                entity.HasKey(e => e.IdRolMenu);
                entity.ToTable("RolMenu");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdRol);

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdMenu);

                entity.HasOne(d => d.IdStatusRegistroNavigation)
                    .WithMany(p => p.RolMenu)
                    .HasForeignKey(d => d.IdStatusRegistro);
            });

            //Mapeo Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario);
                entity.ToTable("c_Usuario");

                entity.Property(e => e.nombre).HasMaxLength(100);
                entity.Property(e => e.correo).HasMaxLength(100);
                entity.Property(e => e.clave).HasMaxLength(100);
            });
        }
    }
}