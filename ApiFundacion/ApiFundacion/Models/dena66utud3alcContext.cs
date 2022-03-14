using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiFundacion.Models
{
    public partial class dena66utud3alcContext : DbContext
    {
        public dena66utud3alcContext()
        {
        }

        public dena66utud3alcContext(DbContextOptions<dena66utud3alcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Areasxproyecto> Areasxproyectos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Departamentosxproyecto> Departamentosxproyectos { get; set; }
        public virtual DbSet<Equipoxproyecto> Equipoxproyectos { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Publicacionesxproyecto> Publicacionesxproyectos { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Validadore> Validadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=ec2-54-208-17-82.compute-1.amazonaws.com; port=5432; user id = cvhnqxepgyjbyw; password = bf6a0decb9ebd3865e80df79e7b04de51cd2b38000be41fa27c2c9d9c454d276; database=dena66utud3alc; pooling = true; SSL Mode=Prefer;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Area1)
                    .HasMaxLength(255)
                    .HasColumnName("area")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial059)
                    .HasMaxLength(1)
                    .HasColumnName("trial059")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Areasxproyecto>(entity =>
            {
                entity.HasKey(e => new { e.Idproyecto, e.Idarea })
                    .HasName("areasxproyecto$primarykey");

                entity.ToTable("areasxproyecto");

                entity.HasComment("TRIAL");

                entity.HasIndex(e => e.Idarea, "areasxproyecto$idarea");

                entity.Property(e => e.Idproyecto)
                    .HasColumnName("idproyecto")
                    .HasComment("TRIAL");

                entity.Property(e => e.Idarea)
                    .HasColumnName("idarea")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial069)
                    .HasMaxLength(1)
                    .HasColumnName("trial069")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Areasxproyectos)
                    .HasForeignKey(d => d.Idarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("areasxproyecto$_c__database_proyectos_be_mdb__areasareasxproyec");

                entity.HasOne(d => d.IdproyectoNavigation)
                    .WithMany(p => p.Areasxproyectos)
                    .HasForeignKey(d => d.Idproyecto)
                    .HasConstraintName("areasxproyecto$_c__database_proyectos_be_mdb__proyectosareasxpr");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamentos");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Departamento1)
                    .HasMaxLength(255)
                    .HasColumnName("departamento")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial079)
                    .HasMaxLength(1)
                    .HasColumnName("trial079")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Departamentosxproyecto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departamentosxproyecto");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .HasColumnName("departamento")
                    .HasComment("TRIAL");

                entity.Property(e => e.Idproyecto)
                    .HasColumnName("idproyecto")
                    .HasDefaultValueSql("0")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nrodepartamento)
                    .HasColumnName("nrodepartamento")
                    .HasDefaultValueSql("0")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial092)
                    .HasMaxLength(1)
                    .HasColumnName("trial092")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Equipoxproyecto>(entity =>
            {
                entity.HasKey(e => new { e.IdProyecto, e.IdPersonal })
                    .HasName("equipoxproyecto$primarykey");

                entity.ToTable("equipoxproyecto");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("id_proyecto")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdPersonal)
                    .HasColumnName("id_personal")
                    .HasComment("TRIAL");

                entity.Property(e => e.Coordinador)
                    .HasColumnName("coordinador")
                    .HasDefaultValueSql("false")
                    .HasComment("TRIAL");

                entity.Property(e => e.FuncionTarea)
                    .HasMaxLength(255)
                    .HasColumnName("funcion_tarea")
                    .HasComment("TRIAL");

                entity.Property(e => e.SsmaTimestamp)
                    .IsRequired()
                    .HasColumnName("ssma_timestamp")
                    .HasComment("TRIAL");

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .HasColumnName("texto")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial098)
                    .HasMaxLength(1)
                    .HasColumnName("trial098")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Equipoxproyectos)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equipoxproyecto$_c__database_proyectos_be_mdb__personalequipoxp");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Equipoxproyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("equipoxproyecto$_c__database_proyectos_be_mdb__proyectosequipox");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("personal");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasComment("TRIAL");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre")
                    .HasComment("TRIAL");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password")
                    .HasComment("TRIAL");

                entity.Property(e => e.Sector)
                    .HasMaxLength(255)
                    .HasColumnName("sector")
                    .HasComment("TRIAL");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .HasColumnName("titulo")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial105)
                    .HasMaxLength(1)
                    .HasColumnName("trial105")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("proyectos");

                entity.HasComment("TRIAL");

                entity.HasIndex(e => e.IdArea, "proyectos$id_area");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.AnioFinalizacion)
                    .HasColumnName("anio_finalizacion")
                    .HasComment("TRIAL");

                entity.Property(e => e.AnioInicio)
                    .HasColumnName("anio_inicio")
                    .HasComment("TRIAL");

                entity.Property(e => e.Certconformidad)
                    .HasColumnName("certconformidad")
                    .HasDefaultValueSql("false")
                    .HasComment("TRIAL");

                entity.Property(e => e.Certificadopor)
                    .HasColumnName("certificadopor")
                    .HasDefaultValueSql("0")
                    .HasComment("TRIAL");

                entity.Property(e => e.ConsultoresAsoc)
                    .HasColumnName("consultores_asoc")
                    .HasComment("TRIAL");

                entity.Property(e => e.Contratante)
                    .HasMaxLength(255)
                    .HasColumnName("contratante")
                    .HasComment("TRIAL");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .HasColumnName("departamento")
                    .HasComment("TRIAL");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasComment("TRIAL");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(255)
                    .HasColumnName("dirección")
                    .HasComment("TRIAL");

                entity.Property(e => e.EnCurso)
                    .HasColumnName("en_curso")
                    .HasDefaultValueSql("false")
                    .HasComment("TRIAL");

                entity.Property(e => e.FichaLista)
                    .HasColumnName("ficha_lista")
                    .HasDefaultValueSql("false")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdArea)
                    .HasColumnName("id_area")
                    .HasComment("TRIAL");

                entity.Property(e => e.MesFinalizacion)
                    .HasColumnName("mes_finalizacion")
                    .HasComment("TRIAL");

                entity.Property(e => e.MesInicio)
                    .HasColumnName("mes_inicio")
                    .HasComment("TRIAL");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(255)
                    .HasColumnName("moneda")
                    .HasComment("TRIAL");

                entity.Property(e => e.MontoContrato)
                    .HasColumnName("monto_contrato")
                    .HasComment("TRIAL");

                entity.Property(e => e.NroContrato)
                    .HasMaxLength(255)
                    .HasColumnName("nro_contrato")
                    .HasComment("TRIAL");

                entity.Property(e => e.PaisRegion)
                    .HasMaxLength(255)
                    .HasColumnName("pais-region")
                    .HasComment("TRIAL");

                entity.Property(e => e.Resultados)
                    .HasColumnName("resultados")
                    .HasComment("TRIAL");

                entity.Property(e => e.SsmaTimestamp)
                    .IsRequired()
                    .HasColumnName("ssma_timestamp")
                    .HasComment("TRIAL");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .HasColumnName("titulo")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial118)
                    .HasMaxLength(1)
                    .HasColumnName("trial118")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Publicacionesxproyecto>(entity =>
            {
                entity.HasKey(e => e.IdPublicacion)
                    .HasName("publicacionesxproyecto$primarykey");

                entity.ToTable("publicacionesxproyecto");

                entity.HasComment("TRIAL");

                entity.HasIndex(e => e.IdProyecto, "publicacionesxproyecto$id_proyecto");

                entity.Property(e => e.IdPublicacion)
                    .HasColumnName("id_publicacion")
                    .HasComment("TRIAL");

                entity.Property(e => e.Año)
                    .HasMaxLength(255)
                    .HasColumnName("año")
                    .HasComment("TRIAL");

                entity.Property(e => e.Codigobcs)
                    .HasMaxLength(255)
                    .HasColumnName("codigobcs")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("id_proyecto")
                    .HasComment("TRIAL");

                entity.Property(e => e.Medio)
                    .HasMaxLength(255)
                    .HasColumnName("medio")
                    .HasComment("TRIAL");

                entity.Property(e => e.Publicacion)
                    .HasMaxLength(255)
                    .HasColumnName("publicacion")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial131)
                    .HasMaxLength(1)
                    .HasColumnName("trial131")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Publicacionesxproyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publicacionesxproyecto$_c__database_proyectos_be_mdb__proyectos");
            });

            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("pk__sysdiagr__c2b05b61c61709e0");

                entity.ToTable("sysdiagrams");

                entity.HasComment("TRIAL");

                entity.HasIndex(e => new { e.PrincipalId, e.Name }, "uk_principal_name")
                    .IsUnique();

                entity.Property(e => e.DiagramId)
                    .HasColumnName("diagram_id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Definition)
                    .HasColumnName("definition")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.PrincipalId)
                    .HasColumnName("principal_id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial141)
                    .HasMaxLength(1)
                    .HasColumnName("trial141")
                    .HasComment("TRIAL");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Validadore>(entity =>
            {
                entity.ToTable("validadores");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre")
                    .HasComment("TRIAL");

                entity.Property(e => e.Sector)
                    .HasMaxLength(255)
                    .HasColumnName("sector")
                    .HasComment("TRIAL");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .HasColumnName("titulo")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial147)
                    .HasMaxLength(1)
                    .HasColumnName("trial147")
                    .HasComment("TRIAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
