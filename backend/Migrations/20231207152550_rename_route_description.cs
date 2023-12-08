using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRoute.Migrations
{
    /// <inheritdoc />
    public partial class rename_route_description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "Routes",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Routes",
                newName: "Desctiption");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");
        }
    }
}
