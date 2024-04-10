using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2_StepLast.Migrations
{
    /// <inheritdoc />
    public partial class waigaya2init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "created_at", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(320), "回復アイテム" },
                    { 2, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(321), "武器" },
                    { 3, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(323), "防具" },
                    { 4, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(324), "家電" },
                    { 5, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(325), "生活用品" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category_id", "created_at", "delete_at", "description", "name", "price" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(480), null, "エクスカリバーには、普通の剣には無い特別な力が備わって\r\nいたと考えられています。敵の攻撃を跳ね返す魔力や、所持\r\n者に無敵の力を与える等の能力が伝承されています。", "エクスカリバー", 54000m },
                    { 2, 3, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(482), null, "ユニクロで売ってます", "ヒートテック", 2000m },
                    { 3, 1, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(484), null, "ダイソンではない", "掃除機", 30000m },
                    { 4, 5, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(485), null, "たんぱく質を英語でいうとプロテイン", "プロテイン", 4000m },
                    { 5, 5, new DateTime(2024, 4, 10, 10, 52, 8, 186, DateTimeKind.Local).AddTicks(487), null, "ただの水です", "500mlの水", 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
