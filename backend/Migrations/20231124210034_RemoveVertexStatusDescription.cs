using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRoute.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVertexStatusDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDescription",
                table: "VertexStatuses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusDescription",
                table: "VertexStatuses",
                type: "text",
                nullable: true);
        }
    }
}
