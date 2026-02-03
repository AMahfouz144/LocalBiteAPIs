using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class edit_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_GuestUser_GuestUserId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestUser",
                table: "GuestUser");

            migrationBuilder.RenameTable(
                name: "GuestUser",
                newName: "GuestUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GuestUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestUsers",
                table: "GuestUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_GuestUsers_GuestUserId",
                table: "Order",
                column: "GuestUserId",
                principalTable: "GuestUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_GuestUsers_GuestUserId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestUsers",
                table: "GuestUsers");

            migrationBuilder.RenameTable(
                name: "GuestUsers",
                newName: "GuestUser");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GuestUser",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestUser",
                table: "GuestUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_GuestUser_GuestUserId",
                table: "Order",
                column: "GuestUserId",
                principalTable: "GuestUser",
                principalColumn: "Id");
        }
    }
}
