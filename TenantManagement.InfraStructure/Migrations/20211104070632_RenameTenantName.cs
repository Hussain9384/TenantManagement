using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantManagement.InfraStructure.Migrations
{
    public partial class RenameTenantName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TenantProperties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TenantProperties");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tenants",
                newName: "Name");
        }
    }
}
