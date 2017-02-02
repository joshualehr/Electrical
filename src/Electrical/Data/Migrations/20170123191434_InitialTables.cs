using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electrical.Data.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    FileLink = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    JobCode = table.Column<string>(maxLength: 20, nullable: false),
                    PostalCode = table.Column<int>(nullable: true),
                    ProjectManagerId = table.Column<string>(maxLength: 450, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(nullable: false),
                    Designation = table.Column<string>(maxLength: 20, nullable: false),
                    ListOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<Guid>(nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.UnitOfMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<int>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Building_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Model_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContact",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContact", x => new { x.ProjectId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ProjectContact_AspNetUsers_ContactId",
                        column: x => x.ContactId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectContact_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDocument",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDocument", x => new { x.ProjectId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_ProjectDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDocument_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingDocument",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingDocument", x => new { x.BuildingId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_BuildingDocument_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    BuildingId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    ModelId = table.Column<Guid>(nullable: true),
                    PostalCode = table.Column<int>(nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    StatusChanged = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Area_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Area_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelDocument",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDocument", x => new { x.ModelId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_ModelDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelDocument_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelMaterial",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMaterial", x => new { x.ModelId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ModelMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelMaterial_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelMaterial_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaDocument",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaDocument", x => new { x.AreaId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_AreaDocument_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaMaterial",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMaterial", x => new { x.AreaId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_AreaMaterial_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaMaterial_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trade",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_BuildingId",
                table: "Area",
                column: "BuildingId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Area_ModelId",
                table: "Area",
                column: "ModelId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Area_StatusId",
                table: "Area",
                column: "StatusId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_AreaDocument_AreaId",
                table: "AreaDocument",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDocument_DocumentId",
                table: "AreaDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaMaterial_AreaId",
                table: "AreaMaterial",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaMaterial_MaterialId",
                table: "AreaMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaMaterial_UnitOfMeasureId",
                table: "AreaMaterial",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_ProjectId",
                table: "Building",
                column: "ProjectId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingDocument_BuildingId",
                table: "BuildingDocument",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingDocument_DocumentId",
                table: "BuildingDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_UnitOfMeasureId",
                table: "Material",
                column: "UnitOfMeasureId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Model_ProjectId",
                table: "Model",
                column: "ProjectId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ModelDocument_DocumentId",
                table: "ModelDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDocument_ModelId",
                table: "ModelDocument",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMaterial_MaterialId",
                table: "ModelMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMaterial_ModelId",
                table: "ModelMaterial",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMaterial_UnitOfMeasureId",
                table: "ModelMaterial",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ContactId",
                table: "ProjectContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ProjectId",
                table: "ProjectContact",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDocument_DocumentId",
                table: "ProjectDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDocument_ProjectId",
                table: "ProjectDocument",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Trade",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AreaDocument");

            migrationBuilder.DropTable(
                name: "AreaMaterial");

            migrationBuilder.DropTable(
                name: "BuildingDocument");

            migrationBuilder.DropTable(
                name: "ModelDocument");

            migrationBuilder.DropTable(
                name: "ModelMaterial");

            migrationBuilder.DropTable(
                name: "ProjectContact");

            migrationBuilder.DropTable(
                name: "ProjectDocument");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
