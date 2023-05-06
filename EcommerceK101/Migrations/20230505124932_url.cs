using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceK101.Migrations
{
    /// <inheritdoc />
    public partial class url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "SocialTeams",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "SocialTeams");
        }
    }
}
