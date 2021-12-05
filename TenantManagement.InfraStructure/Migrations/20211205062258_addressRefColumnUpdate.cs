using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantManagement.InfraStructure.Migrations
{
    public partial class addressRefColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Addresses_AddressId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Tenants");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TenantId",
                table: "Addresses",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Tenants_TenantId",
                table: "Addresses",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Tenants_TenantId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_TenantId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Addresses_AddressId",
                table: "Tenants",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
