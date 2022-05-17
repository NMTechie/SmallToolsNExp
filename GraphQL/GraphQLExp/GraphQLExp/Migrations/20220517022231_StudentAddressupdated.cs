using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLExp.Migrations
{
    public partial class StudentAddressupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_ContactAddressAddressID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ContactAddressAddressID",
                table: "Students",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ContactAddressAddressID",
                table: "Students",
                newName: "IX_Students_AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressID",
                table: "Students",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Students",
                newName: "ContactAddressAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AddressID",
                table: "Students",
                newName: "IX_Students_ContactAddressAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_ContactAddressAddressID",
                table: "Students",
                column: "ContactAddressAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
