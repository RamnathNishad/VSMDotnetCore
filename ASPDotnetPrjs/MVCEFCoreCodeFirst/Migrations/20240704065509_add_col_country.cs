using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCEFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class add_col_country : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "tbl_customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "tbl_customer");
        }
    }
}
