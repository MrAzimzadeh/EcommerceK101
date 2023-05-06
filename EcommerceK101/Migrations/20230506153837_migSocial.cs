using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceK101.Migrations
{
    /// <inheritdoc />
    public partial class migSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialTeams");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropColumn(
                name: "Departman",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Teams",
                newName: "Position");

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsNetworks_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsNetworks_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsNetworks_SocialNetworkId",
                table: "TeamsNetworks",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsNetworks_TeamId",
                table: "TeamsNetworks",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsNetworks");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Teams",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Departman",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialTeams_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialTeams_SocialId",
                table: "SocialTeams",
                column: "SocialId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialTeams_TeamId",
                table: "SocialTeams",
                column: "TeamId");
        }
    }
}
