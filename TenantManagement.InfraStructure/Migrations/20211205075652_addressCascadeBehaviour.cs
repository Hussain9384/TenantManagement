using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantManagement.InfraStructure.Migrations
{
    public partial class addressCascadeBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperties_Tenants_TenantId",
                table: "TenantProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperties_Tenants_TenantId",
                table: "TenantProperties",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperties_Tenants_TenantId",
                table: "TenantProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperties_Tenants_TenantId",
                table: "TenantProperties",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
