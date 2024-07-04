using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCEFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class project_manager_tbl_creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_manager",
                columns: table => new
                {
                    MgrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_manager", x => x.MgrId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrId = table.Column<int>(type: "int", nullable: false),
                    managerMgrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_project_tbl_manager_managerMgrId",
                        column: x => x.managerMgrId,
                        principalTable: "tbl_manager",
                        principalColumn: "MgrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_project_managerMgrId",
                table: "tbl_project",
                column: "managerMgrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_project");

            migrationBuilder.DropTable(
                name: "tbl_manager");
        }
    }
}
