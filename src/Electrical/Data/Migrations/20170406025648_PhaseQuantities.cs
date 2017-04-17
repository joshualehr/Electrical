using Microsoft.EntityFrameworkCore.Migrations;

namespace Electrical.Data.Migrations
{
    public partial class PhaseQuantities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinishQuantity",
                table: "ModelMaterial",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RoughQuantity",
                table: "ModelMaterial",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FinishQuantity",
                table: "AreaMaterial",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RoughQuantity",
                table: "AreaMaterial",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishQuantity",
                table: "ModelMaterial");

            migrationBuilder.DropColumn(
                name: "RoughQuantity",
                table: "ModelMaterial");

            migrationBuilder.DropColumn(
                name: "FinishQuantity",
                table: "AreaMaterial");

            migrationBuilder.DropColumn(
                name: "RoughQuantity",
                table: "AreaMaterial");
        }
    }
}
