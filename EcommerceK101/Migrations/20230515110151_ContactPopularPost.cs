using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceK101.Migrations
{
    /// <inheritdoc />
    public partial class ContactPopularPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Contacts");
        }
    }
}
