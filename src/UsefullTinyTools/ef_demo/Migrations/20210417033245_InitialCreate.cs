using Microsoft.EntityFrameworkCore.Migrations;

namespace ef_demo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ModelAId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelBs_ModelAs_ModelAId",
                        column: x => x.ModelAId,
                        principalTable: "ModelAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelBs_ModelAId",
                table: "ModelBs",
                column: "ModelAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelBs");

            migrationBuilder.DropTable(
                name: "ModelAs");
        }
    }
}
