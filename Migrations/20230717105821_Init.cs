using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace anketdeneme.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memnuniyets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemnuniyetDerecesi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memnuniyets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sorulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesajKutusu = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    MemnuniyetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorulars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sorulars_Memnuniyets_MemnuniyetID",
                        column: x => x.MemnuniyetID,
                        principalTable: "Memnuniyets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Memnuniyets",
                columns: new[] { "Id", "MemnuniyetDerecesi" },
                values: new object[,]
                {
                    { 1, "Çok Memnunum" },
                    { 2, "Memnunum" },
                    { 3, "Nötrüm" },
                    { 4, "Memnun Değilim" },
                    { 5, "Hiç Memnun Değilim" },
                    { 6, "Memnun Değilim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sorulars_MemnuniyetID",
                table: "Sorulars",
                column: "MemnuniyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sorulars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Memnuniyets");

            migrationBuilder.DropTable(
                name: "AppRoles");
        }
    }
}
