using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CumputerWishlist.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSpec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSpecComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerSpecId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSpecComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComponentType",
                columns: new[] { "Id", "Name", "MaxLimit" },
                values: new object[,]
                {
                    { 1, "Ram", 1 },
                    { 2, "Hard Drive", 1 },
                    { 3, "Ports", 30 },
                    { 4, "Graphics Card", 2},
                    { 5, "Power Supply", 1 },
                    { 6, "Processor", 1 }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentTypeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "8 GB" },
                    { 2, 1, "16 GB" },
                    { 3, 1, "32 GB" },
                    { 4, 1, "2 GB" },
                    { 5, 1, "512 MB" },
                    { 6, 2, "1 TB SSD" },
                    { 7, 2, "2 TB HDD" },
                    { 8, 2, "3 TB HDD" },
                    { 9, 2, "4 TB HDD" },
                    { 10, 2, "750 GB SDD" },
                    { 11, 2, "2 TB SDD" },
                    { 12, 2, "500 GB SDD" },
                    { 13, 2, "80 GB SSD" },
                    { 14, 3, "USB 3.0" },
                    { 15, 3, "USB 2.0" },
                    { 16, 3, "USB C" },
                    { 17, 4, "NVIDIA GeForce GTX 770" },
                    { 18, 4, "NVIDIA GeForce GTX 960" },
                    { 19, 4, "Radeon R7360" },
                    { 20, 4, "NVIDIA GeForce GTX 1080" },
                    { 21, 4, "Radeon RX 480" },
                    { 22, 4, "Radeon R9 380" },
                    { 23, 4, "AMD FirePro W4100" },
                    { 24, 5, "500 W PSU"},
                    { 25, 5, "450 W PSU"},
                    { 26, 5, "1000 W PSU"},
                    { 27, 5, "750 W PSU"},
                    { 28, 5, "508 W PSU"},
                    { 29, 5, "700 W PSU"},
                    { 30, 6, "Intel® Celeron™ N3050 Processor"},
                    { 31, 6, "AMD FX 4300 Processor"},
                    { 32, 6, "AMD Athlon Quad-Core APU Athlon 5150"},
                    { 33, 6, "AMD FX 8-Core Black Edition FX-8350"},
                    { 34, 6, "AMD FX 8-Core Black Edition FX-8370"},
                    { 35, 6, "Intel Core i7-6700K 4GHz Processor"},
                    { 36, 6, "Intel® Core™ i5-6400 Processor"},
                    { 37, 6, "Intel Core i7 Extreme Edition 3 GHz Processor"},
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                });

            migrationBuilder.InsertData(
                table: "ComputerSpec",
                columns: new[] { "Id", "Name", "UserId", "IsSystem", "Weight" },
                values: new object[,]
                {
                    { 1, "Machine 1", 1, true, "8.1 kg" },
                    { 2, "Machine 2", 1, true, "12 kg" },
                    { 3, "Machine 3", 1, true, "16 lb" },
                    { 4, "Machine 4", 1, true, "13.8 lb" },
                    { 5, "Machine 5", 1, true, "7 kg" },
                    { 6, "Machine 6", 1, true, "6 kg" },
                    { 7, "Machine 7", 1, true, "15 lb" },
                    { 8, "Machine 8", 1, true, "8 lb" },
                    { 9, "Machine 9", 1, true, "9 kg" },
                    { 10, "Machine 10", 1, true, "22 lb" },
                });

            migrationBuilder.InsertData(
                table: "ComputerSpecComponent",
                columns: new[] { "ComputerSpecId", "ComponentId", "Count" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 6, 1 },
                    { 1, 14, 2 },
                    { 1, 15, 4 },
                    { 1, 17, 1 },
                    { 1, 24, 1 },
                    { 1, 30, 1 },
                    { 2, 2, 1 },
                    { 2, 7, 1 },
                    { 2, 14, 3 },
                    { 2, 15, 4 },
                    { 2, 18, 1 },
                    { 2, 24, 1 },
                    { 2, 31, 1 },
                    { 3, 1, 1 },
                    { 3, 8, 1 },
                    { 3, 14, 4 },
                    { 3, 15, 4 },
                    { 3, 19, 1 },
                    { 3, 25, 1 },
                    { 3, 32, 1 },
                    { 4, 2, 1 },
                    { 4, 9, 1 },
                    { 4, 14, 4 },
                    { 4, 15, 5 },
                    { 4, 20, 1 },
                    { 4, 24, 1 },
                    { 4, 33, 1 },
                    { 5, 3, 1 },
                    { 5, 10, 1 },
                    { 5, 14, 2 },
                    { 5, 15, 2 },
                    { 5, 16, 1 },
                    { 5, 21, 1 },
                    { 5, 26, 1 },
                    { 5, 34, 1 },
                    { 6, 2, 1 },
                    { 6, 11, 1 },
                    { 6, 14, 4 },
                    { 6, 16, 2 },
                    { 6, 22, 1 },
                    { 6, 25, 1 },
                    { 6, 35, 1 },
                    { 7, 1, 1 },
                    { 7, 7, 1 },
                    { 7, 14, 8 },
                    { 7, 20, 1 },
                    { 7, 26, 1 },
                    { 7, 35, 1 },
                    { 8, 2, 1 },
                    { 8, 12, 1 },
                    { 8, 15, 4 },
                    { 8, 17, 1 },
                    { 8, 27, 1 },
                    { 8, 36, 1 },
                    { 9, 4, 1 },
                    { 9, 7, 1 },
                    { 9, 14, 10 },
                    { 9, 15, 10 },
                    { 9, 16, 10 },
                    { 9, 23, 1 },
                    { 9, 28, 1 },
                    { 9, 37, 1 },
                    { 10, 5, 1 },
                    { 10, 13, 1 },
                    { 10, 14, 19 },
                    { 10, 15, 10 },
                    { 10, 21, 1 },
                    { 10, 29, 1 },
                    { 10, 36, 1 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "ComponentType");

            migrationBuilder.DropTable(
                name: "ComputerSpec");

            migrationBuilder.DropTable(
                name: "ComputerSpecComponent");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
