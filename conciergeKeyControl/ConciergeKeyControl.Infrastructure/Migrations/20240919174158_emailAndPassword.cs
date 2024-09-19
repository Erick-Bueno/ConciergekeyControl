using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConciergeKeyControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emailAndPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "users",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "users");
        }
    }
}
