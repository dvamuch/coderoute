using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeRoute.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Desctiption = table.Column<string>(type: "text", nullable: false),
                    MarkDownPage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.UniqueConstraint("AK_Routes_Title", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "RouteStatuses",
                columns: table => new
                {
                    RouteStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStatuses", x => x.RouteStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.UniqueConstraint("AK_Users_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Vertexes",
                columns: table => new
                {
                    VertexId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MarkdownPage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertexes", x => x.VertexId);
                });

            migrationBuilder.CreateTable(
                name: "VertexStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertexStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "RelatedRoutes",
                columns: table => new
                {
                    CurrentRouteId = table.Column<int>(type: "integer", nullable: false),
                    RelatedRouteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedRoutes", x => new { x.CurrentRouteId, x.RelatedRouteId });
                    table.ForeignKey(
                        name: "FK_RelatedRoutes_Routes_CurrentRouteId",
                        column: x => x.CurrentRouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedRoutes_Routes_RelatedRouteId",
                        column: x => x.RelatedRouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoutes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RouteId = table.Column<int>(type: "integer", nullable: false),
                    RouteStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoutes", x => new { x.UserId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_UserRoutes_RouteStatuses_RouteStatusId",
                        column: x => x.RouteStatusId,
                        principalTable: "RouteStatuses",
                        principalColumn: "RouteStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoutes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VertexConnections",
                columns: table => new
                {
                    CurrentVertexId = table.Column<int>(type: "integer", nullable: false),
                    PreviousVertexId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertexConnections", x => new { x.CurrentVertexId, x.PreviousVertexId });
                    table.ForeignKey(
                        name: "FK_VertexConnections_Vertexes_CurrentVertexId",
                        column: x => x.CurrentVertexId,
                        principalTable: "Vertexes",
                        principalColumn: "VertexId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VertexConnections_Vertexes_PreviousVertexId",
                        column: x => x.PreviousVertexId,
                        principalTable: "Vertexes",
                        principalColumn: "VertexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVertexes",
                columns: table => new
                {
                    VertexId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVertexes", x => new { x.UserId, x.VertexId });
                    table.ForeignKey(
                        name: "FK_UserVertexes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVertexes_VertexStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VertexStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVertexes_Vertexes_VertexId",
                        column: x => x.VertexId,
                        principalTable: "Vertexes",
                        principalColumn: "VertexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedRoutes_RelatedRouteId",
                table: "RelatedRoutes",
                column: "RelatedRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutes_RouteId",
                table: "UserRoutes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutes_RouteStatusId",
                table: "UserRoutes",
                column: "RouteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVertexes_StatusId",
                table: "UserVertexes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVertexes_VertexId",
                table: "UserVertexes",
                column: "VertexId");

            migrationBuilder.CreateIndex(
                name: "IX_VertexConnections_PreviousVertexId",
                table: "VertexConnections",
                column: "PreviousVertexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedRoutes");

            migrationBuilder.DropTable(
                name: "UserRoutes");

            migrationBuilder.DropTable(
                name: "UserVertexes");

            migrationBuilder.DropTable(
                name: "VertexConnections");

            migrationBuilder.DropTable(
                name: "RouteStatuses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VertexStatuses");

            migrationBuilder.DropTable(
                name: "Vertexes");
        }
    }
}
