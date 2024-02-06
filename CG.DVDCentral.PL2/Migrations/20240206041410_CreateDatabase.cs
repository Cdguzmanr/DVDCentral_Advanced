using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CG.DVDCentral.PL2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDirector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDirector_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    InStkQty = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblMovie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "tblDirector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_FormatId",
                        column: x => x.FormatId,
                        principalTable: "tblFormat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRating",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre_Id", x => x.Id);
                    table.ForeignKey(
                        name: "tblMovieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tblMovieGenre_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblCart_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Phone", "State", "UserId", "ZIP" },
                values: new object[,]
                {
                    { new Guid("060c9614-0bfb-4630-bc66-07c146ab5418"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("f9a65374-f511-4046-8553-cf63d00daac1"), "53142" },
                    { new Guid("a1205689-0a58-4006-bfb2-b19c7b52fe3c"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("5bbe6f5f-a240-4114-b1ee-7628bbcba23a"), "54935" },
                    { new Guid("e24b670d-cb9b-474a-bfac-2c98c9ec7df7"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("dd5c9fef-1c98-4272-8311-d809ff34ca8a"), "56495" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("29c237ef-1076-4b2d-b9cc-45353e9bba78"), "Rob", "Reiner" },
                    { new Guid("2b9a6f42-7740-4152-b72e-da86b3901c5a"), "John", "Avildsen" },
                    { new Guid("4b72b3ae-d2b6-443c-9a23-b984aaba650f"), "Other", "Other" },
                    { new Guid("ab2d1a48-cc2a-4ac9-89a3-868cae16ce3b"), "Clint", "Eastwood" },
                    { new Guid("b37b2ac3-cb99-4e46-811a-fa721f1710ef"), "George", "Lucas" },
                    { new Guid("eba15250-036b-4098-af12-0d14050851f6"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("62f2e0e0-bbd9-49ab-a43e-47d55c0541a1"), "Other" },
                    { new Guid("7e136a2c-77a9-4940-81ac-a4858174b118"), "DVD" },
                    { new Guid("80506d2d-b654-45dc-96bb-88ab49b709dc"), "VHS" },
                    { new Guid("c5df5222-2ee1-471e-964b-2acafebd686d"), "Blu-Ray" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("30865c0f-9643-4236-8aee-3ee2d473098e"), "Mystery" },
                    { new Guid("4617915c-ba97-431e-876f-bc30b58d8673"), "Musical" },
                    { new Guid("609e10d0-704c-40b5-b77d-7e8f375f9cc3"), "Sci-Fi" },
                    { new Guid("6ecd3242-7da4-4118-951e-f594c6c6fe72"), "Romance" },
                    { new Guid("72e500dd-f4ee-4ae9-a610-7d58adbfeb64"), "Comedy" },
                    { new Guid("7ea9d043-9d88-4d77-a8dc-b3b9d71ae3ac"), "Documentary" },
                    { new Guid("9051a2a0-1b1c-4b28-9e30-b003c61200f6"), "Western" },
                    { new Guid("9f43c1e1-730b-43e8-856d-73fb0cd16f73"), "Horror" },
                    { new Guid("bb016b72-a7d9-449e-8b24-da069541cccb"), "Other" },
                    { new Guid("f4a5680d-7361-4970-9a06-7c9377b86efb"), "Action" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a5be276-0690-44f9-be15-f839d1b37a30"), new Guid("e24b670d-cb9b-474a-bfac-2c98c9ec7df7"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dd5c9fef-1c98-4272-8311-d809ff34ca8a") },
                    { new Guid("22aab2fb-96c1-4ae7-a04e-a1085e1cd99b"), new Guid("060c9614-0bfb-4630-bc66-07c146ab5418"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dd5c9fef-1c98-4272-8311-d809ff34ca8a") },
                    { new Guid("9b401be4-2eec-42af-9c56-83a987a8f254"), new Guid("060c9614-0bfb-4630-bc66-07c146ab5418"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9a65374-f511-4046-8553-cf63d00daac1") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("55b9576f-83b4-49d6-982c-a595af9e797a"), 8.9900000000000002, new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4"), new Guid("1a5be276-0690-44f9-be15-f839d1b37a30"), 0 },
                    { new Guid("994eb40f-0762-4856-acc4-aea47cd0a86b"), 9.9900000000000002, new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86"), new Guid("1a5be276-0690-44f9-be15-f839d1b37a30"), 0 },
                    { new Guid("b50e7767-9c3a-4cc3-8bce-d60b61465f03"), 10.99, new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86"), new Guid("22aab2fb-96c1-4ae7-a04e-a1085e1cd99b"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("08eaa2b2-0aa7-4c79-90e6-096739566c51"), "R" },
                    { new Guid("38b5aa50-ad63-45ba-a2d9-9b30c0309e3f"), "PG" },
                    { new Guid("49bd933f-e667-4e4f-b2cc-8abbb2a92020"), "PG-13" },
                    { new Guid("aef9f710-2cfc-42df-b9d1-816d0cefa21f"), "G" },
                    { new Guid("df0d7692-d1bf-426e-a1f5-3d2fc3b0d592"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("5bbe6f5f-a240-4114-b1ee-7628bbcba23a"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("dd5c9fef-1c98-4272-8311-d809ff34ca8a"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("f9a65374-f511-4046-8553-cf63d00daac1"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("2400b3dc-c062-46d5-a158-627e684a4d6a"), new Guid("5bbe6f5f-a240-4114-b1ee-7628bbcba23a") },
                    { new Guid("7782f567-b3c5-48d4-b088-720abce168d7"), new Guid("dd5c9fef-1c98-4272-8311-d809ff34ca8a") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "InStkQty", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("eba15250-036b-4098-af12-0d14050851f6"), new Guid("7e136a2c-77a9-4940-81ac-a4858174b118"), "Jaws1.jpg", 1, new Guid("49bd933f-e667-4e4f-b2cc-8abbb2a92020"), "Jaws" },
                    { new Guid("25161eb2-d757-4bc7-b620-7769bff8e263"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("29c237ef-1076-4b2d-b9cc-45353e9bba78"), new Guid("c5df5222-2ee1-471e-964b-2acafebd686d"), "PrincessBride.jpg", 4, new Guid("38b5aa50-ad63-45ba-a2d9-9b30c0309e3f"), "The Princess Bride" },
                    { new Guid("bcb0624c-8aa7-4e90-919c-a062cf9ba803"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("eba15250-036b-4098-af12-0d14050851f6"), new Guid("7e136a2c-77a9-4940-81ac-a4858174b118"), "PaleRider.jpg", 1, new Guid("49bd933f-e667-4e4f-b2cc-8abbb2a92020"), "Pale Rider" },
                    { new Guid("c8926029-a577-4b2a-8650-85d0bf213aaf"), 6.9900000000000002, "Other", new Guid("2b9a6f42-7740-4152-b72e-da86b3901c5a"), new Guid("80506d2d-b654-45dc-96bb-88ab49b709dc"), "Rocky.jpg", 2, new Guid("aef9f710-2cfc-42df-b9d1-816d0cefa21f"), "Other" },
                    { new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("2b9a6f42-7740-4152-b72e-da86b3901c5a"), new Guid("80506d2d-b654-45dc-96bb-88ab49b709dc"), "Rocky.jpg", 2, new Guid("aef9f710-2cfc-42df-b9d1-816d0cefa21f"), "Rocky" },
                    { new Guid("d4d6eb05-e971-417e-a657-7d2399d2f3e5"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("b37b2ac3-cb99-4e46-811a-fa721f1710ef"), new Guid("c5df5222-2ee1-471e-964b-2acafebd686d"), "IndianaJonesLastCrusade.jpg", 2, new Guid("08eaa2b2-0aa7-4c79-90e6-096739566c51"), "Indiana Jones and the Last Crusade" },
                    { new Guid("ff5df706-2968-4307-9f18-560e240ecd89"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("eba15250-036b-4098-af12-0d14050851f6"), new Guid("7e136a2c-77a9-4940-81ac-a4858174b118"), "StarWarsNewHope.jpg", 1, new Guid("49bd933f-e667-4e4f-b2cc-8abbb2a92020"), "Star Wars: Episode IV – A New Hope" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("38b7a04e-4dae-4e68-a35e-cc4d660ae83a"), new Guid("7782f567-b3c5-48d4-b088-720abce168d7"), new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86"), 1 },
                    { new Guid("966c0d44-f1e2-4bd5-ba96-cebd41814e63"), new Guid("2400b3dc-c062-46d5-a158-627e684a4d6a"), new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86"), 2 },
                    { new Guid("9e9fcfff-8ba9-4041-8aeb-0b34f76eac2f"), new Guid("2400b3dc-c062-46d5-a158-627e684a4d6a"), new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("07ede865-4f1a-4f04-be89-6258d222cbba"), new Guid("7ea9d043-9d88-4d77-a8dc-b3b9d71ae3ac"), new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4") },
                    { new Guid("2ed49b42-7483-435e-aeff-3af4fc6f3b8c"), new Guid("4617915c-ba97-431e-876f-bc30b58d8673"), new Guid("ff5df706-2968-4307-9f18-560e240ecd89") },
                    { new Guid("2ee0157b-1ca4-4570-885a-ed023397b0e6"), new Guid("9f43c1e1-730b-43e8-856d-73fb0cd16f73"), new Guid("d4d6eb05-e971-417e-a657-7d2399d2f3e5") },
                    { new Guid("416ac5f4-d0a4-483c-8032-a571908a74ee"), new Guid("7ea9d043-9d88-4d77-a8dc-b3b9d71ae3ac"), new Guid("25161eb2-d757-4bc7-b620-7769bff8e263") },
                    { new Guid("55743949-a0f5-4cc0-aa4f-ee8cde831053"), new Guid("609e10d0-704c-40b5-b77d-7e8f375f9cc3"), new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4") },
                    { new Guid("558e1efc-ca95-44e1-8aa0-f76b66de1b2a"), new Guid("9f43c1e1-730b-43e8-856d-73fb0cd16f73"), new Guid("d25b5bd5-5fbd-4073-8dd1-9161cd7452a4") },
                    { new Guid("67b9e4df-32bf-49a0-a61a-29012ad5ab5e"), new Guid("72e500dd-f4ee-4ae9-a610-7d58adbfeb64"), new Guid("25161eb2-d757-4bc7-b620-7769bff8e263") },
                    { new Guid("817e0ad7-676d-42a8-ab26-99eac1b2879c"), new Guid("30865c0f-9643-4236-8aee-3ee2d473098e"), new Guid("bcb0624c-8aa7-4e90-919c-a062cf9ba803") },
                    { new Guid("85172f3f-f683-4bcf-987a-f49715e3a54c"), new Guid("9f43c1e1-730b-43e8-856d-73fb0cd16f73"), new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86") },
                    { new Guid("8bf8f228-798d-4b06-9feb-916cbd88491a"), new Guid("9f43c1e1-730b-43e8-856d-73fb0cd16f73"), new Guid("ff5df706-2968-4307-9f18-560e240ecd89") },
                    { new Guid("a18517a9-08ab-421b-ad0a-a6539cf11097"), new Guid("7ea9d043-9d88-4d77-a8dc-b3b9d71ae3ac"), new Guid("d4d6eb05-e971-417e-a657-7d2399d2f3e5") },
                    { new Guid("a9043a96-ab5d-4024-8c26-af00df439ef3"), new Guid("609e10d0-704c-40b5-b77d-7e8f375f9cc3"), new Guid("2241f40d-d254-4c93-b886-a6a1353f0d86") },
                    { new Guid("e99eb1e7-7835-4e2e-a539-deac7d17bd70"), new Guid("f4a5680d-7361-4970-9a06-7c9377b86efb"), new Guid("25161eb2-d757-4bc7-b620-7769bff8e263") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_CartId",
                table: "tblCartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_MovieId",
                table: "tblCartItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_DirectorId",
                table: "tblMovie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_FormatId",
                table: "tblMovie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_RatingId",
                table: "tblMovie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");
        }
    }
}
