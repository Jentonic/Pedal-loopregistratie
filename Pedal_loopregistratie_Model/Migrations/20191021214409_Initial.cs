using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedal_loopregistratie_Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residences",
                columns: table => new
                {
                    ResidenceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residences", x => x.ResidenceId);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                columns: table => new
                {
                    RunnerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ResidenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.RunnerId);
                    table.ForeignKey(
                        name: "FK_Runners_Residences_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residences",
                        principalColumn: "ResidenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laps",
                columns: table => new
                {
                    LapId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Milliseconds = table.Column<double>(nullable: false),
                    AverageSpeedKmH = table.Column<double>(nullable: false),
                    AverageSpeedS = table.Column<double>(nullable: false),
                    RunnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laps", x => x.LapId);
                    table.ForeignKey(
                        name: "FK_Laps_Runners_RunnerId",
                        column: x => x.RunnerId,
                        principalTable: "Runners",
                        principalColumn: "RunnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueRunners",
                columns: table => new
                {
                    QueueRunnerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<int>(nullable: false),
                    RunnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueRunners", x => x.QueueRunnerId);
                    table.ForeignKey(
                        name: "FK_QueueRunners_Runners_RunnerId",
                        column: x => x.RunnerId,
                        principalTable: "Runners",
                        principalColumn: "RunnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 1, "Pedal is een overkoepelende organisatie voor studentenresidenties.", null, "Pedal" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 2, "Hesteria is de studentenclub voor iedereen uit Heist en omstreken.", null, "Hesteria" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 3, "", null, "Heilige Geestcollege" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 4, "", null, "Amerikaans College" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 5, "", null, "Don Bosco" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 6, "", null, "Regina Mundi" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 7, "", null, "Copal" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 8, "", null, "Cruysberghs" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 9, "", null, "Justus Lipsius" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 10, "", null, "Waterview" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "ImageString", "Name" },
                values: new object[] { 11, "", null, "Studax" });

            migrationBuilder.CreateIndex(
                name: "IX_Laps_RunnerId",
                table: "Laps",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueRunners_RunnerId",
                table: "QueueRunners",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_ResidenceId",
                table: "Runners",
                column: "ResidenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laps");

            migrationBuilder.DropTable(
                name: "QueueRunners");

            migrationBuilder.DropTable(
                name: "Runners");

            migrationBuilder.DropTable(
                name: "Residences");
        }
    }
}
