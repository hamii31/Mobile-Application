using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoptionMobileApplication.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("7de57db2-117e-4989-8819-60280a7bb1a6"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("9b69a333-3f20-4b10-9b85-68301a171ead"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("a4fa24fc-ff8f-4d68-bd81-bf1296491b69"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("d7af5d42-98be-408a-a4ac-a3d667d8a1da"));

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "BirthDate", "Breed", "Description", "Gender", "Image", "IsActive", "PetName", "Price", "View" },
                values: new object[,]
                {
                    { new Guid("1fdca0bb-1329-423f-b0eb-606100ed303a"), 1, new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Snowshoe", "Loving, curious, family-oriented, vocal", 1, "pearl.jpg", true, "Pearl", 500.0, 0 },
                    { new Guid("28d3482d-f301-40e7-b855-a8a0006c5eb3"), 1, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Belgian Malinois", "confident, smart, hardworking", 0, "jack.jpg", true, "Jack", 500.0, 0 },
                    { new Guid("e03dbb3e-09d1-4add-9e4e-32f501e7a1a5"), 1, new DateTime(2007, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Siamese", "judgemental, loving, intelligent, fighter", 1, "ioana.png", true, "Ioana", 5000.0, 0 },
                    { new Guid("ed273b65-b091-49f1-8b05-35ae7313e0af"), 1, new DateTime(2015, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Alaskan Klee Kai", "loyal, intelligent, vigilant", 0, "alaskan_klee_kai.jpg", true, "Bushu", 250.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("1fdca0bb-1329-423f-b0eb-606100ed303a"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("28d3482d-f301-40e7-b855-a8a0006c5eb3"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("e03dbb3e-09d1-4add-9e4e-32f501e7a1a5"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ed273b65-b091-49f1-8b05-35ae7313e0af"));

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "BirthDate", "Breed", "Description", "Gender", "Image", "IsActive", "PetName", "Price", "View" },
                values: new object[,]
                {
                    { new Guid("7de57db2-117e-4989-8819-60280a7bb1a6"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Belgian Malinois", "confident, smart, hardworking", 0, "jack.jpg", false, "Jack", 500.0, 0 },
                    { new Guid("9b69a333-3f20-4b10-9b85-68301a171ead"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Siamese", "judgemental, loving, intelligent, fighter", 1, "ioana.png", false, "Ioana", 5000.0, 0 },
                    { new Guid("a4fa24fc-ff8f-4d68-bd81-bf1296491b69"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat - Snowshoe", "Loving, curious, family-oriented, vocal", 1, "pearl.jpg", false, "Pearl", 500.0, 0 },
                    { new Guid("d7af5d42-98be-408a-a4ac-a3d667d8a1da"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog - Alaskan Klee Kai", "loyal, intelligent, vigilant", 0, "alaskan_klee_kai.jpg", false, "Bushu", 250.0, 0 }
                });
        }
    }
}
