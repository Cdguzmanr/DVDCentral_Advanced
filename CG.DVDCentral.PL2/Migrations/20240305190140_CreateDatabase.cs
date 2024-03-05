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
                    Quantity = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("489c9a88-15cf-4874-8a4b-a8120f4a3a69"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("f17436a8-c5eb-45d8-9e2f-d1fe47605788"), "56495" },
                    { new Guid("5fe58522-a21f-44b2-93b7-48c1d0f60bd2"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("f065f2ba-3d3d-48e0-98f2-7e5f52c75852"), "53142" },
                    { new Guid("dd4b4a89-b684-4118-ab96-1031aa0efa6c"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("6613b086-b951-43e2-b907-33b7f887d2e8"), "54935" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0fa78be9-abc0-4ad3-8ca5-4979aae5eb83"), "Other", "Other" },
                    { new Guid("70c60603-ea68-4bdd-a41f-98aa3376cc48"), "George", "Lucas" },
                    { new Guid("7220c09e-e524-4bb8-aa0d-c211f0f2d3d7"), "John", "Avildsen" },
                    { new Guid("7b43c1fe-3469-4667-b240-7eee57a215da"), "Clint", "Eastwood" },
                    { new Guid("b1e9807d-0ca3-42ac-a24e-fb9f2d37a79a"), "Steven", "Spielberg" },
                    { new Guid("b8ce006b-3fad-4930-ac76-d1e7e975c2ff"), "Rob", "Reiner" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("46869db3-53ce-4968-a7fc-5bac849088a4"), "Other" },
                    { new Guid("675c1a01-426c-4484-a674-c21eab575325"), "Blu-Ray" },
                    { new Guid("77551c26-daad-4bd6-9953-004989ba4f40"), "DVD" },
                    { new Guid("7c2a1791-3ed9-4832-9b7e-315b612f9ead"), "VHS" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("0bcfcc24-7d24-47ea-8573-5dcdd8a35db6"), "Comedy" },
                    { new Guid("0dd595c3-6504-4669-b02c-0ccacada5572"), "Romance" },
                    { new Guid("0fb6185a-bfd9-4ddc-839d-d05f185fdab3"), "Other" },
                    { new Guid("104f40f9-c257-4567-bc5d-a1ad4bbf3cd7"), "Western" },
                    { new Guid("517c8cb2-cfb5-4dda-b3eb-9d04840ba8c5"), "Musical" },
                    { new Guid("9e200592-0399-4e36-9e91-306ed9a5d38b"), "Horror" },
                    { new Guid("b35d5db0-babc-4e50-bf2c-d1fe268e5118"), "Sci-Fi" },
                    { new Guid("b4c7ff04-7c46-41e3-949b-56bad56f4829"), "Action" },
                    { new Guid("d7b28d30-4f84-4530-9003-682c280ee35c"), "Mystery" },
                    { new Guid("f50e39e2-6653-45c8-9fa6-49382578ae6c"), "Documentary" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId", "tblCustomerId" },
                values: new object[,]
                {
                    { new Guid("2de42f75-03fd-4fa4-bbb4-1ea96cd62773"), new Guid("489c9a88-15cf-4874-8a4b-a8120f4a3a69"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f17436a8-c5eb-45d8-9e2f-d1fe47605788"), null },
                    { new Guid("74c5e1b0-fa53-456e-8864-18c79a27b182"), new Guid("5fe58522-a21f-44b2-93b7-48c1d0f60bd2"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f065f2ba-3d3d-48e0-98f2-7e5f52c75852"), null },
                    { new Guid("cf8b49a1-50c2-4f18-b687-80453e18e471"), new Guid("5fe58522-a21f-44b2-93b7-48c1d0f60bd2"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f17436a8-c5eb-45d8-9e2f-d1fe47605788"), null }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5d5206d8-b489-4908-a3c3-b9e422b3c455"), 10.99, new Guid("e2e500e2-042e-4753-978e-1f689c71de62"), new Guid("cf8b49a1-50c2-4f18-b687-80453e18e471"), 0 },
                    { new Guid("9ce65324-197b-45ef-8e77-65fb17731f8e"), 8.9900000000000002, new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1"), new Guid("2de42f75-03fd-4fa4-bbb4-1ea96cd62773"), 0 },
                    { new Guid("f8d3d87c-dcd7-4d75-a164-2c4010a63bea"), 9.9900000000000002, new Guid("e2e500e2-042e-4753-978e-1f689c71de62"), new Guid("2de42f75-03fd-4fa4-bbb4-1ea96cd62773"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("217630a3-6d8a-49bb-9ccf-90321f634845"), "R" },
                    { new Guid("2a041ea5-93be-4bb6-a375-4010143b05cd"), "Other" },
                    { new Guid("692c95fc-44cc-49ad-9719-26ca9e0cf84f"), "G" },
                    { new Guid("b9431834-b4a7-4331-b27b-d7b87bcc163a"), "PG-13" },
                    { new Guid("d8bfa1c3-9b50-46fc-a5c3-41515dca6b7a"), "PG" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("6613b086-b951-43e2-b907-33b7f887d2e8"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("f065f2ba-3d3d-48e0-98f2-7e5f52c75852"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("f17436a8-c5eb-45d8-9e2f-d1fe47605788"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ecb02ac-fe41-4233-baa7-d94a987293c5"), new Guid("f17436a8-c5eb-45d8-9e2f-d1fe47605788") },
                    { new Guid("528e76f5-2b45-4ae7-bf40-d3956198da92"), new Guid("6613b086-b951-43e2-b907-33b7f887d2e8") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("1498286f-5a42-454e-a1f2-b1b7263df6c9"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("b1e9807d-0ca3-42ac-a24e-fb9f2d37a79a"), new Guid("77551c26-daad-4bd6-9953-004989ba4f40"), "PaleRider.jpg", 1, new Guid("b9431834-b4a7-4331-b27b-d7b87bcc163a"), "Pale Rider" },
                    { new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("7220c09e-e524-4bb8-aa0d-c211f0f2d3d7"), new Guid("7c2a1791-3ed9-4832-9b7e-315b612f9ead"), "Rocky.jpg", 2, new Guid("692c95fc-44cc-49ad-9719-26ca9e0cf84f"), "Rocky" },
                    { new Guid("5d9313c7-320f-423c-a773-4d3edbe3108e"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("b1e9807d-0ca3-42ac-a24e-fb9f2d37a79a"), new Guid("77551c26-daad-4bd6-9953-004989ba4f40"), "StarWarsNewHope.jpg", 1, new Guid("b9431834-b4a7-4331-b27b-d7b87bcc163a"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("7146eb5a-6d0e-4271-9c94-08a4f00a25d2"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("70c60603-ea68-4bdd-a41f-98aa3376cc48"), new Guid("675c1a01-426c-4484-a674-c21eab575325"), "IndianaJonesLastCrusade.jpg", 2, new Guid("217630a3-6d8a-49bb-9ccf-90321f634845"), "Indiana Jones and the Last Crusade" },
                    { new Guid("8ece9ad5-9bba-4596-8a81-a761322e1700"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("b8ce006b-3fad-4930-ac76-d1e7e975c2ff"), new Guid("675c1a01-426c-4484-a674-c21eab575325"), "PrincessBride.jpg", 4, new Guid("d8bfa1c3-9b50-46fc-a5c3-41515dca6b7a"), "The Princess Bride" },
                    { new Guid("e2e500e2-042e-4753-978e-1f689c71de62"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("b1e9807d-0ca3-42ac-a24e-fb9f2d37a79a"), new Guid("77551c26-daad-4bd6-9953-004989ba4f40"), "Jaws1.jpg", 1, new Guid("b9431834-b4a7-4331-b27b-d7b87bcc163a"), "Jaws" },
                    { new Guid("fa97268e-975c-433a-ba6a-4d6f34c88e31"), 6.9900000000000002, "Other", new Guid("7220c09e-e524-4bb8-aa0d-c211f0f2d3d7"), new Guid("7c2a1791-3ed9-4832-9b7e-315b612f9ead"), "Rocky.jpg", 2, new Guid("692c95fc-44cc-49ad-9719-26ca9e0cf84f"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("30452b0e-24fd-4a3c-b812-1ea54306223e"), new Guid("528e76f5-2b45-4ae7-bf40-d3956198da92"), new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1"), 1 },
                    { new Guid("3a593afe-023e-4ab9-a545-df900058b76f"), new Guid("4ecb02ac-fe41-4233-baa7-d94a987293c5"), new Guid("e2e500e2-042e-4753-978e-1f689c71de62"), 1 },
                    { new Guid("d5c1453d-fa52-4393-adfb-417b63e79f11"), new Guid("528e76f5-2b45-4ae7-bf40-d3956198da92"), new Guid("e2e500e2-042e-4753-978e-1f689c71de62"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0de8b1b4-1407-4b19-b708-3611ebb5a0d3"), new Guid("517c8cb2-cfb5-4dda-b3eb-9d04840ba8c5"), new Guid("5d9313c7-320f-423c-a773-4d3edbe3108e") },
                    { new Guid("117515c5-8353-4dfb-9734-1dc90ecfb2d8"), new Guid("b35d5db0-babc-4e50-bf2c-d1fe268e5118"), new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1") },
                    { new Guid("18eac644-f5fd-48c4-9952-8fd04d8ac0f3"), new Guid("0bcfcc24-7d24-47ea-8573-5dcdd8a35db6"), new Guid("8ece9ad5-9bba-4596-8a81-a761322e1700") },
                    { new Guid("30818342-083e-4abe-b242-a882ff1ff189"), new Guid("9e200592-0399-4e36-9e91-306ed9a5d38b"), new Guid("7146eb5a-6d0e-4271-9c94-08a4f00a25d2") },
                    { new Guid("4fdafdce-804c-4fd9-a185-28c8f87b4c4e"), new Guid("9e200592-0399-4e36-9e91-306ed9a5d38b"), new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1") },
                    { new Guid("5786a156-545b-4fe4-bf63-c77413615ca2"), new Guid("b35d5db0-babc-4e50-bf2c-d1fe268e5118"), new Guid("e2e500e2-042e-4753-978e-1f689c71de62") },
                    { new Guid("88ab6549-be09-4a32-b770-356f1bf4b1c3"), new Guid("f50e39e2-6653-45c8-9fa6-49382578ae6c"), new Guid("7146eb5a-6d0e-4271-9c94-08a4f00a25d2") },
                    { new Guid("95f74758-447d-4145-a045-003d4279de77"), new Guid("f50e39e2-6653-45c8-9fa6-49382578ae6c"), new Guid("3d370bd2-7387-44cc-b5af-53ed5dda59f1") },
                    { new Guid("9adc122e-b3b1-448b-b3d9-652531b31a77"), new Guid("b4c7ff04-7c46-41e3-949b-56bad56f4829"), new Guid("8ece9ad5-9bba-4596-8a81-a761322e1700") },
                    { new Guid("b877ceea-4096-4fff-9b4e-7e0fb408b155"), new Guid("d7b28d30-4f84-4530-9003-682c280ee35c"), new Guid("1498286f-5a42-454e-a1f2-b1b7263df6c9") },
                    { new Guid("cd5d8062-8bb9-44c2-9fa6-dd8ed0af156d"), new Guid("f50e39e2-6653-45c8-9fa6-49382578ae6c"), new Guid("8ece9ad5-9bba-4596-8a81-a761322e1700") },
                    { new Guid("e5158029-742e-4006-ae2c-21c4081cc46a"), new Guid("9e200592-0399-4e36-9e91-306ed9a5d38b"), new Guid("e2e500e2-042e-4753-978e-1f689c71de62") },
                    { new Guid("e9317878-875b-4ce6-a46d-06e534e47e87"), new Guid("9e200592-0399-4e36-9e91-306ed9a5d38b"), new Guid("5d9313c7-320f-423c-a773-4d3edbe3108e") }
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

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMovies]
                AS
                    select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                    r.Description RatingDescription,
                    f.Description FormatDescription,
                    d.FirstName, d.LastName
                    from tblMovie m
                    inner join tblRating r on m.RatingId = r.Id
                    inner join tblFormat f on m.FormatId = f.Id
                    inner join tblDirector d on m.DirectorId = d.Id
 
                RETURN 0");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMoviesByGenre]
                     @GenreName VARCHAR(20)
                AS
                     select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                     r.Description RatingDescription,
                     f.Description FormatDescription,
                     d.FirstName, d.LastName
                     from tblMovie m
                     inner join tblRating r on m.RatingId = r.Id
                     inner join tblFormat f on m.FormatId = f.Id
                     inner join tblDirector d on m.DirectorId = d.Id
                     inner join tblMovieGenre mg on m.Id = mg.MovieId
                     inner join tblGenre g on mg.GenreId = g.Id
                     WHERE g.Description Like '%' + @GenreName + '%'
                RETURN 0
                ");
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
