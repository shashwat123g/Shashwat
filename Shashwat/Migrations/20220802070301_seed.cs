using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shashwat.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PieId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PiePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.OrderId);
                });

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 3,
                column: "Price",
                value: 12.95m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 3,
                column: "Price",
                value: 18.95m);
        }
    }
}
