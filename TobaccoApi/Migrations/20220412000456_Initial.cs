using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TobaccoApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leafs",
                columns: table => new
                {
                    LeafId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leafs", x => x.LeafId);
                });

            migrationBuilder.CreateTable(
                name: "LeafDetails",
                columns: table => new
                {
                    LeafDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCT = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeafId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeafDetails", x => x.LeafDetailId);
                    table.ForeignKey(
                        name: "FK_LeafDetails_Leafs_LeafId",
                        column: x => x.LeafId,
                        principalTable: "Leafs",
                        principalColumn: "LeafId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeafDetails_LeafId",
                table: "LeafDetails",
                column: "LeafId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeafDetails");

            migrationBuilder.DropTable(
                name: "Leafs");
        }
    }
}
