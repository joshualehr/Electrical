using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electrical.Data.Migrations
{
    public partial class AddedToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    ToDoId = table.Column<Guid>(nullable: false),
                    ParentToDoId = table.Column<Guid>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: false),
                    AssignedToId = table.Column<string>(maxLength: 450, nullable: false),
                    Heading = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    ListOrder = table.Column<short>(nullable: false),
                    StartOn = table.Column<DateTime>(nullable: true),
                    CompletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDo_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDo_AspNetUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDo_ToDo_ParentToDoId",
                        column: x => x.ParentToDoId,
                        principalTable: "ToDo",
                        principalColumn: "ToDoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_AreaId",
                table: "ToDo",
                column: "AreaId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_AssignedToId",
                table: "ToDo",
                column: "AssignedToId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ParentToDoId",
                table: "ToDo",
                column: "ParentToDoId")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");
        }
    }
}
