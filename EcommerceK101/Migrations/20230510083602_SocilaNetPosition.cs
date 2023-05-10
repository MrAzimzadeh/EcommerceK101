using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceK101.Migrations
{
    /// <inheritdoc />
    public partial class SocilaNetPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "SocialNetworks",
                newName: "BaseUrl");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PositionId",
                table: "Teams",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Positions_PositionId",
                table: "Teams",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Positions_PositionId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PositionId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "BaseUrl",
                table: "SocialNetworks",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
