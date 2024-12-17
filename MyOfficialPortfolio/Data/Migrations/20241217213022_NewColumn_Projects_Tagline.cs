using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOfficialPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumn_Projects_Tagline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tagline",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tagline",
                table: "Projects");
        }
    }
}
