using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    /// <inheritdoc />
    public partial class AddExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExperienceTitle = table.Column<string>(type: "TEXT", nullable: false),
                    ExperienceNotes = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExperienceUserLocation = table.Column<string>(type: "TEXT", nullable: true),
                    FirstGooglePlaceId = table.Column<string>(type: "TEXT", nullable: false),
                    SecondGooglePlaceId = table.Column<string>(type: "TEXT", nullable: true),
                    ThirdGooglePlaceId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");
        }
    }
}
