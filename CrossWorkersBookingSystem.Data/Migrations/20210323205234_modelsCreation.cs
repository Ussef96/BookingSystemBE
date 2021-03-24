using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossWorkersBookingSystem.Data.Migrations
{
    public partial class modelsCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedQuantity = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 1, "Anna Karenina", 10 });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 2, "To Kill a Mockingbird", 5 });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 3, "The Great Gatsby", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ResourceId",
                table: "Booking",
                column: "ResourceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
