using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Electrical.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Electrical.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaMaterial> AreaMaterials { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelMaterial> ModelMaterials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Area>().ToTable("Area");
            builder.Entity<Area>()
                .HasIndex(i => i.BuildingId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<Area>()
                .HasIndex(i => i.ModelId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<Area>()
                .HasIndex(i => i.StatusId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<AreaDocument>().HasKey(k => new { k.AreaId, k.DocumentId });
            builder.Entity<AreaDocument>()
                .HasOne(ad => ad.Area)
                .WithMany(a => a.AreaDocuments)
                .HasForeignKey(ad => ad.AreaId);
            builder.Entity<AreaDocument>()
                .HasOne(ad => ad.Document)
                .WithMany(d => d.AreaDocuments)
                .HasForeignKey(ad => ad.DocumentId);
            builder.Entity<AreaMaterial>().ToTable("AreaMaterial");
            builder.Entity<AreaMaterial>().HasKey(k => new { k.AreaId, k.MaterialId });
            builder.Entity<Building>().ToTable("Building");
            builder.Entity<Building>()
                .HasIndex(i => i.ProjectId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<BuildingDocument>().HasKey(k => new { k.BuildingId, k.DocumentId });
            builder.Entity<BuildingDocument>()
                .HasOne(bd => bd.Building)
                .WithMany(b => b.BuildingDocuments)
                .HasForeignKey(bd => bd.BuildingId);
            builder.Entity<BuildingDocument>()
                .HasOne(bd => bd.Document)
                .WithMany(d => d.BuildingDocuments)
                .HasForeignKey(bd => bd.DocumentId);
            builder.Entity<Document>().ToTable("Document");
            builder.Entity<Material>().ToTable("Material");
            builder.Entity<Material>()
                .HasIndex(i => i.UnitOfMeasureId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<Model>().ToTable("Model");
            builder.Entity<Model>()
                .HasIndex(i => i.ProjectId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<ModelDocument>().HasKey(k => new { k.ModelId, k.DocumentId });
            builder.Entity<ModelDocument>()
                .HasOne(md => md.Model)
                .WithMany(m => m.ModelDocuments)
                .HasForeignKey(md => md.ModelId);
            builder.Entity<ModelDocument>()
                .HasOne(md => md.Document)
                .WithMany(d => d.ModelDocuments)
                .HasForeignKey(md => md.DocumentId);
            builder.Entity<ModelMaterial>().ToTable("ModelMaterial");
            builder.Entity<ModelMaterial>().HasKey(k => new { k.ModelId, k.MaterialId });
            builder.Entity<Project>().ToTable("Project");
            builder.Entity<Project>()
                .HasIndex(i => i.ProjectManagerId)
                .ForSqlServerIsClustered(false)
                .IsUnique(false);
            builder.Entity<ProjectContact>().HasKey(k => new { k.ProjectId, k.ContactId });
            builder.Entity<ProjectContact>()
                .HasOne(pc => pc.Project)
                .WithMany(p => p.ProjectContacts)
                .HasForeignKey(pc => pc.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProjectContact>()
                .HasOne(pc => pc.Contact)
                .WithMany(au => au.ProjectContacts)
                .HasForeignKey(pd => pd.ContactId);
            builder.Entity<ProjectDocument>().HasKey(k => new { k.ProjectId, k.DocumentId });
            builder.Entity<ProjectDocument>()
                .HasOne(pd => pd.Project)
                .WithMany(p => p.ProjectDocuments)
                .HasForeignKey(pd => pd.ProjectId);
            builder.Entity<ProjectDocument>()
                .HasOne(pd => pd.Document)
                .WithMany(d => d.ProjectDocuments)
                .HasForeignKey(pd => pd.DocumentId);
            builder.Entity<Status>().ToTable("Status");
            builder.Entity<UnitOfMeasure>().ToTable("UnitOfMeasure");
            builder.Entity<UnitOfMeasure>()
                .HasMany(um => um.ModelMaterial)
                .WithOne(mm => mm.UnitOfMeasure)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UnitOfMeasure>()
                .HasMany(um => um.AreaMaterial)
                .WithOne(am => am.UnitOfMeasure)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
