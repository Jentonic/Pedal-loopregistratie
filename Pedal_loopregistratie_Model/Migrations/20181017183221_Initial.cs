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
                    Description = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "Name" },
                values: new object[] { 1, "Pedal is een overkoepelende organisatie voor studentenresidenties.", "Pedal" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "ResidenceId", "Description", "Name" },
                values: new object[] { 2, "Hesteria is studentenclub voor iedereen uit Heist en omstreken.", "Hesteria" });

            migrationBuilder.CreateIndex(
                name: "IX_Runners_ResidenceId",
                table: "Runners",
                column: "ResidenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runners");

            migrationBuilder.DropTable(
                name: "Residences");
        }
    }
}
