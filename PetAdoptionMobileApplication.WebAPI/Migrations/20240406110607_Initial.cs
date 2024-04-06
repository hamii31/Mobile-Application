using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoptionMobileApplication.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    View = table.Column<int>(type: "int", nullable: false),
                    AdoptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdoptedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favs_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "BirthDate", "Breed", "Description", "Gender", "Image", "IsActive", "PetName", "Price", "View" },
                values: new object[,]
                {
                    { new Guid("014bdd2b-8285-4e18-a323-2fda881593ff"), 1, new DateTime(2015, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Alaskan Klee Kai", "loyal, intelligent, vigilant", 0, "alaskan_klee_kai.jpg", true, "Bushu", 250.0, 0 },
                    { new Guid("17ed8790-9f25-4331-b04b-628bfc437f06"), 1, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Belgian Malinois", "confident, smart, hardworking", 0, "jack.jpg", true, "Jack", 500.0, 0 },
                    { new Guid("24d1dd1c-5779-4b13-aea9-5718b658c41a"), 1, new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Snowshoe", "Loving, curious, family-oriented, vocal", 1, "pearl.jpg", true, "Pearl", 500.0, 0 },
                    { new Guid("3b43b08c-7ccf-4221-8f07-3fe1086c9a00"), 1, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parrot - Amazon Parrot", "Loves to sing, adores seeds, likes to fly freely and always finds his way back home", 0, "parrot.jpg", true, "Alonso", 300.0, 0 },
                    { new Guid("6c6390cf-0aed-4e1f-8d9f-25794993b809"), 1, new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bunny - House Bunny", "Playful, caring, loving", 0, "bobo.jpg", true, "Bobo", 150.0, 0 },
                    { new Guid("af3268a0-1384-445d-b90d-3619e2db09e1"), 1, new DateTime(2007, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Siamese", "judgemental, loving, intelligent, fighter", 1, "ioana.png", true, "Ioana", 5000.0, 0 },
                    { new Guid("df848db3-048d-4b25-bbea-26a8458fa1f3"), 1, new DateTime(2000, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turtle - Pond Slider", "Easy-going, chill, peaceful, loves cabbage", 1, "tess.jpg", true, "Tess", 160.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_PetId",
                table: "Adoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_UserId",
                table: "Adoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favs_PetId",
                table: "Favs",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Favs_UserId",
                table: "Favs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Favs");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
