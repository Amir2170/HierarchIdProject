using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyProject.Migrations
{
    /// <inheritdoc />
    public partial class levelField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "People");
        }
    }
}
