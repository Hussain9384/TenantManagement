using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantManagement.InfraStructure.Migrations
{
    public partial class UpdateTenantPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tenants");
        }
    }
}
