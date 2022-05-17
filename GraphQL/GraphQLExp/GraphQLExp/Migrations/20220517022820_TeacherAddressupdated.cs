using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLExp.Migrations
{
    public partial class TeacherAddressupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Addresses_ConatctAddressID",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "ConatctAddressID",
                table: "Teachers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ConatctAddressID",
                table: "Teachers",
                newName: "IX_Teachers_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Addresses_AddressId",
                table: "Teachers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Addresses_AddressId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Teachers",
                newName: "ConatctAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_AddressId",
                table: "Teachers",
                newName: "IX_Teachers_ConatctAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Addresses_ConatctAddressID",
                table: "Teachers",
                column: "ConatctAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
