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
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    tblCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblCustomer_tblCustomerId",
                        column: x => x.tblCustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "Id");
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
                    { new Guid("2f28c79b-3ee3-41ce-bbec-40ec6c0680a7"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("14a6de53-8b21-4878-a258-03093df3abb8"), "53142" },
                    { new Guid("66641f9a-782a-4750-ab18-4d5ae1f8fed9"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("e9381517-43e7-42b3-ae3c-7161047d3058"), "54935" },
                    { new Guid("b36d8a97-dbf5-4620-8a02-0f6ccdf0b18e"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("55220e09-4c53-4f2e-9324-0539d91afba6"), "56495" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0a81c3de-fe0c-4214-aa0e-a4729287ddc4"), "George", "Lucas" },
                    { new Guid("28f4523c-6b8e-42cb-9c43-c3dde9d5bcb9"), "Rob", "Reiner" },
                    { new Guid("2d8883f2-9420-42a8-8efe-63c382dd0151"), "Other", "Other" },
                    { new Guid("42a7011e-4d05-482e-9a85-ea83f7c774ca"), "Clint", "Eastwood" },
                    { new Guid("ccf900ea-4ed5-4952-9f9c-46186905f608"), "John", "Avildsen" },
                    { new Guid("e7515488-bed0-4d89-89e6-5acaa1951334"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("4d95b3a5-3454-4413-bc6f-54905866a4d2"), "Blu-Ray" },
                    { new Guid("606c44e1-a700-4aea-be02-e6429dfd4eee"), "DVD" },
                    { new Guid("7208b62a-ddc7-450a-b0af-048352e6442c"), "Other" },
                    { new Guid("c5677f6b-3bc7-4347-91e7-755f5956d3a6"), "VHS" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("27b54b42-8c0d-4e82-8121-b206ca5b082b"), "Comedy" },
                    { new Guid("29599a08-add2-4762-ad56-916bd85284ee"), "Sci-Fi" },
                    { new Guid("2d94a56f-9502-4ed2-b5d8-9ccbb18bd055"), "Mystery" },
                    { new Guid("8d94bf52-3592-4f9c-902c-bff858673c66"), "Other" },
                    { new Guid("95710746-2b31-440d-b8ca-f9fba789030c"), "Action" },
                    { new Guid("97dd6634-205b-44fd-bf8a-c242497ffe2e"), "Musical" },
                    { new Guid("a0f521c0-4692-42cf-83e5-9124794d50d7"), "Documentary" },
                    { new Guid("ce06d48d-a966-4fe9-8354-1f0e98350aa7"), "Western" },
                    { new Guid("dd72ea4b-37ad-4de7-9f11-0f8ad1d25a2e"), "Romance" },
                    { new Guid("eb50c6ba-2137-4f7e-ae32-884f89bb610b"), "Horror" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId", "tblCustomerId" },
                values: new object[,]
                {
                    { new Guid("34451a94-1593-4050-9f3d-8e05da9f07aa"), new Guid("2f28c79b-3ee3-41ce-bbec-40ec6c0680a7"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55220e09-4c53-4f2e-9324-0539d91afba6"), null },
                    { new Guid("9cf93090-9751-49b7-94d9-8cbd3ab493d6"), new Guid("b36d8a97-dbf5-4620-8a02-0f6ccdf0b18e"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55220e09-4c53-4f2e-9324-0539d91afba6"), null },
                    { new Guid("a0127e27-d5ec-4519-aba7-ed6507c54977"), new Guid("2f28c79b-3ee3-41ce-bbec-40ec6c0680a7"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("14a6de53-8b21-4878-a258-03093df3abb8"), null }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("08bb136e-3d00-4577-8bd4-82345a9849fe"), 10.99, new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76"), new Guid("34451a94-1593-4050-9f3d-8e05da9f07aa"), 0 },
                    { new Guid("7ab47bba-858f-4378-90a2-f4554840f41e"), 9.9900000000000002, new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76"), new Guid("9cf93090-9751-49b7-94d9-8cbd3ab493d6"), 0 },
                    { new Guid("953f9875-2c30-4a6d-b868-42f1de30bed8"), 8.9900000000000002, new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb"), new Guid("9cf93090-9751-49b7-94d9-8cbd3ab493d6"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("6bdf1caa-e8c7-4ae6-8398-980a2c88a25f"), "PG-13" },
                    { new Guid("7db805dd-fc52-4994-9b28-a5592e39218a"), "Other" },
                    { new Guid("8b32b8e3-459f-4091-be26-17aa995c163d"), "PG" },
                    { new Guid("a5812862-a380-4f1a-bc10-994dc823d43a"), "G" },
                    { new Guid("e387bd75-ddc0-49d2-b1a6-b3c2c7c99ce7"), "R" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("14a6de53-8b21-4878-a258-03093df3abb8"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("55220e09-4c53-4f2e-9324-0539d91afba6"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("e9381517-43e7-42b3-ae3c-7161047d3058"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("9286104e-78c6-4960-bd38-598cdf1ffa2b"), new Guid("e9381517-43e7-42b3-ae3c-7161047d3058") },
                    { new Guid("abaedd05-1693-43fb-8ae8-027e83f838d0"), new Guid("55220e09-4c53-4f2e-9324-0539d91afba6") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "InStkQty", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("02773329-62c0-49fd-8fc2-d7c41334b117"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("e7515488-bed0-4d89-89e6-5acaa1951334"), new Guid("606c44e1-a700-4aea-be02-e6429dfd4eee"), "PaleRider.jpg", 1, new Guid("6bdf1caa-e8c7-4ae6-8398-980a2c88a25f"), "Pale Rider" },
                    { new Guid("1f0ddaaf-73db-493a-955e-f89c33bfb693"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("28f4523c-6b8e-42cb-9c43-c3dde9d5bcb9"), new Guid("4d95b3a5-3454-4413-bc6f-54905866a4d2"), "PrincessBride.jpg", 4, new Guid("8b32b8e3-459f-4091-be26-17aa995c163d"), "The Princess Bride" },
                    { new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("e7515488-bed0-4d89-89e6-5acaa1951334"), new Guid("606c44e1-a700-4aea-be02-e6429dfd4eee"), "Jaws1.jpg", 1, new Guid("6bdf1caa-e8c7-4ae6-8398-980a2c88a25f"), "Jaws" },
                    { new Guid("6d6a6859-896f-4798-828e-3f6cc69496e7"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("e7515488-bed0-4d89-89e6-5acaa1951334"), new Guid("606c44e1-a700-4aea-be02-e6429dfd4eee"), "StarWarsNewHope.jpg", 1, new Guid("6bdf1caa-e8c7-4ae6-8398-980a2c88a25f"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("ccf900ea-4ed5-4952-9f9c-46186905f608"), new Guid("c5677f6b-3bc7-4347-91e7-755f5956d3a6"), "Rocky.jpg", 2, new Guid("a5812862-a380-4f1a-bc10-994dc823d43a"), "Rocky" },
                    { new Guid("aa00eb37-3304-40a8-9f5f-bcab7a2eace9"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("0a81c3de-fe0c-4214-aa0e-a4729287ddc4"), new Guid("4d95b3a5-3454-4413-bc6f-54905866a4d2"), "IndianaJonesLastCrusade.jpg", 2, new Guid("e387bd75-ddc0-49d2-b1a6-b3c2c7c99ce7"), "Indiana Jones and the Last Crusade" },
                    { new Guid("c244d656-dee8-4096-9b3d-5e41205a263c"), 6.9900000000000002, "Other", new Guid("ccf900ea-4ed5-4952-9f9c-46186905f608"), new Guid("c5677f6b-3bc7-4347-91e7-755f5956d3a6"), "Rocky.jpg", 2, new Guid("a5812862-a380-4f1a-bc10-994dc823d43a"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("0a73abb6-c3d4-44a6-941a-7c61e01a8cd4"), new Guid("9286104e-78c6-4960-bd38-598cdf1ffa2b"), new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb"), 1 },
                    { new Guid("6fe1c5be-21a6-4819-9a28-329e250d999a"), new Guid("9286104e-78c6-4960-bd38-598cdf1ffa2b"), new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76"), 2 },
                    { new Guid("9ca79bdc-ae3e-4958-aa4d-28b449fd6195"), new Guid("abaedd05-1693-43fb-8ae8-027e83f838d0"), new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("68815e41-729a-4951-8731-7b43a1c4806a"), new Guid("2d94a56f-9502-4ed2-b5d8-9ccbb18bd055"), new Guid("02773329-62c0-49fd-8fc2-d7c41334b117") },
                    { new Guid("87666faa-6336-47e9-8c6a-e2b8e9a43103"), new Guid("95710746-2b31-440d-b8ca-f9fba789030c"), new Guid("1f0ddaaf-73db-493a-955e-f89c33bfb693") },
                    { new Guid("895adb00-eca9-415d-8a54-75eab1b8b45a"), new Guid("a0f521c0-4692-42cf-83e5-9124794d50d7"), new Guid("1f0ddaaf-73db-493a-955e-f89c33bfb693") },
                    { new Guid("8f451281-a45e-44fb-bebc-726dcb630c8a"), new Guid("29599a08-add2-4762-ad56-916bd85284ee"), new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb") },
                    { new Guid("960473fc-50f3-4f8b-8d87-fb7bc07df8c6"), new Guid("eb50c6ba-2137-4f7e-ae32-884f89bb610b"), new Guid("aa00eb37-3304-40a8-9f5f-bcab7a2eace9") },
                    { new Guid("9fcb8104-4ceb-4f8f-b421-1399fe34846e"), new Guid("eb50c6ba-2137-4f7e-ae32-884f89bb610b"), new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb") },
                    { new Guid("ad9f88ab-7b3e-4372-a5f6-ef2bbc82dcaa"), new Guid("29599a08-add2-4762-ad56-916bd85284ee"), new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76") },
                    { new Guid("b33cbf64-faa1-4e5e-941a-f182b2676887"), new Guid("a0f521c0-4692-42cf-83e5-9124794d50d7"), new Guid("9e50e81f-6a6c-4bde-876b-d1844706b4cb") },
                    { new Guid("b4d32263-7096-4026-bf34-cf72d0ec736a"), new Guid("97dd6634-205b-44fd-bf8a-c242497ffe2e"), new Guid("6d6a6859-896f-4798-828e-3f6cc69496e7") },
                    { new Guid("ccfd18f4-0856-42a9-8153-b129ba0df32c"), new Guid("eb50c6ba-2137-4f7e-ae32-884f89bb610b"), new Guid("6d6a6859-896f-4798-828e-3f6cc69496e7") },
                    { new Guid("d32b96b2-c152-4cec-83fe-2b2b0acc3c3e"), new Guid("eb50c6ba-2137-4f7e-ae32-884f89bb610b"), new Guid("4d406d3f-f18b-4dab-baaf-2ea5e86dde76") },
                    { new Guid("e35ee8be-4fac-46de-9c56-ebb342e7315a"), new Guid("a0f521c0-4692-42cf-83e5-9124794d50d7"), new Guid("aa00eb37-3304-40a8-9f5f-bcab7a2eace9") },
                    { new Guid("e873a54d-7111-44a2-bbde-876d2ad39c53"), new Guid("27b54b42-8c0d-4e82-8121-b206ca5b082b"), new Guid("1f0ddaaf-73db-493a-955e-f89c33bfb693") }
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

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_tblCustomerId",
                table: "tblOrder",
                column: "tblCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

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
                name: "tblCustomer");

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
