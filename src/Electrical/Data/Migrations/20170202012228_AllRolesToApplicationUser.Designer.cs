using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Electrical.Data;

namespace Electrical.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170202012228_AllRolesToApplicationUser")]
    partial class AllRolesToApplicationUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Electrical.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AllRoles");

                    b.Property<string>("Company")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Trade")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Electrical.Models.Area", b =>
                {
                    b.Property<Guid>("AreaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("BuildingId");

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Description");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid?>("ModelId");

                    b.Property<int?>("PostalCode");

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 2);

                    b.Property<DateTime>("StatusChanged");

                    b.Property<Guid>("StatusId");

                    b.HasKey("AreaId");

                    b.HasIndex("BuildingId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("ModelId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("StatusId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Electrical.Models.AreaDocument", b =>
                {
                    b.Property<Guid>("AreaId");

                    b.Property<Guid>("DocumentId");

                    b.HasKey("AreaId", "DocumentId");

                    b.HasIndex("AreaId");

                    b.HasIndex("DocumentId");

                    b.ToTable("AreaDocument");
                });

            modelBuilder.Entity("Electrical.Models.AreaMaterial", b =>
                {
                    b.Property<Guid>("AreaId");

                    b.Property<Guid>("MaterialId");

                    b.Property<double>("Quantity");

                    b.Property<Guid>("UnitOfMeasureId");

                    b.HasKey("AreaId", "MaterialId");

                    b.HasIndex("AreaId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("AreaMaterial");
                });

            modelBuilder.Entity("Electrical.Models.Building", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Description");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("PostalCode");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 2);

                    b.HasKey("BuildingId");

                    b.HasIndex("ProjectId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Building");
                });

            modelBuilder.Entity("Electrical.Models.BuildingDocument", b =>
                {
                    b.Property<Guid>("BuildingId");

                    b.Property<Guid>("DocumentId");

                    b.HasKey("BuildingId", "DocumentId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("DocumentId");

                    b.ToTable("BuildingDocument");
                });

            modelBuilder.Entity("Electrical.Models.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FileLink")
                        .IsRequired();

                    b.HasKey("DocumentId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Electrical.Models.Material", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ImagePath");

                    b.Property<Guid>("UnitOfMeasureId");

                    b.HasKey("MaterialId");

                    b.HasIndex("UnitOfMeasureId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Electrical.Models.Model", b =>
                {
                    b.Property<Guid>("ModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("ProjectId");

                    b.HasKey("ModelId");

                    b.HasIndex("ProjectId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Electrical.Models.ModelDocument", b =>
                {
                    b.Property<Guid>("ModelId");

                    b.Property<Guid>("DocumentId");

                    b.HasKey("ModelId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelDocument");
                });

            modelBuilder.Entity("Electrical.Models.ModelMaterial", b =>
                {
                    b.Property<Guid>("ModelId");

                    b.Property<Guid>("MaterialId");

                    b.Property<double>("Quantity");

                    b.Property<Guid>("UnitOfMeasureId");

                    b.HasKey("ModelId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ModelId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("ModelMaterial");
                });

            modelBuilder.Entity("Electrical.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Description");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("JobCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int?>("PostalCode");

                    b.Property<string>("ProjectManagerId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 2);

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectManagerId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Electrical.Models.ProjectContact", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ContactId");

                    b.HasKey("ProjectId", "ContactId");

                    b.HasIndex("ContactId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectContact");
                });

            modelBuilder.Entity("Electrical.Models.ProjectDocument", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("DocumentId");

                    b.HasKey("ProjectId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDocument");
                });

            modelBuilder.Entity("Electrical.Models.Status", b =>
                {
                    b.Property<Guid>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("ListOrder");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Electrical.Models.UnitOfMeasure", b =>
                {
                    b.Property<Guid>("UnitOfMeasureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("UnitOfMeasureId");

                    b.ToTable("UnitOfMeasure");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Electrical.Models.Area", b =>
                {
                    b.HasOne("Electrical.Models.Building", "Building")
                        .WithMany("Areas")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Model", "Model")
                        .WithMany("Areas")
                        .HasForeignKey("ModelId");

                    b.HasOne("Electrical.Models.Status", "Status")
                        .WithMany("Areas")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.AreaDocument", b =>
                {
                    b.HasOne("Electrical.Models.Area", "Area")
                        .WithMany("AreaDocuments")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Document", "Document")
                        .WithMany("AreaDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.AreaMaterial", b =>
                {
                    b.HasOne("Electrical.Models.Area", "Area")
                        .WithMany("AreaMaterial")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Material", "Material")
                        .WithMany("AreaMaterial")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("AreaMaterial")
                        .HasForeignKey("UnitOfMeasureId");
                });

            modelBuilder.Entity("Electrical.Models.Building", b =>
                {
                    b.HasOne("Electrical.Models.Project", "Project")
                        .WithMany("Buildings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.BuildingDocument", b =>
                {
                    b.HasOne("Electrical.Models.Building", "Building")
                        .WithMany("BuildingDocuments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Document", "Document")
                        .WithMany("BuildingDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.Material", b =>
                {
                    b.HasOne("Electrical.Models.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.Model", b =>
                {
                    b.HasOne("Electrical.Models.Project", "Project")
                        .WithMany("Models")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.ModelDocument", b =>
                {
                    b.HasOne("Electrical.Models.Document", "Document")
                        .WithMany("ModelDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Model", "Model")
                        .WithMany("ModelDocuments")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.ModelMaterial", b =>
                {
                    b.HasOne("Electrical.Models.Material", "Material")
                        .WithMany("ModelMaterial")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Model", "Model")
                        .WithMany("ModelMaterial")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("ModelMaterial")
                        .HasForeignKey("UnitOfMeasureId");
                });

            modelBuilder.Entity("Electrical.Models.Project", b =>
                {
                    b.HasOne("Electrical.Models.ApplicationUser", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Electrical.Models.ProjectContact", b =>
                {
                    b.HasOne("Electrical.Models.ApplicationUser", "Contact")
                        .WithMany("ProjectContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Project", "Project")
                        .WithMany("ProjectContacts")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Electrical.Models.ProjectDocument", b =>
                {
                    b.HasOne("Electrical.Models.Document", "Document")
                        .WithMany("ProjectDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.Project", "Project")
                        .WithMany("ProjectDocuments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Electrical.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Electrical.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Electrical.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
