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
                    { new Guid("67c6816d-c550-4572-90c0-40c2196fd524"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("242689f9-8371-48c8-a6d1-4a550b8ced7e"), "53142" },
                    { new Guid("c7f97369-c98a-4be8-9752-ca0d4a15c1e5"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("9506e295-178c-40e8-844f-54ef9bb6f99d"), "54935" },
                    { new Guid("d0b82509-ef1a-437d-a3cc-c944cbfc03e2"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("3b1e3451-68fc-418c-8f8c-53fca468510f"), "56495" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("43974b5e-fbb2-4590-93ee-aef621263256"), "George", "Lucas" },
                    { new Guid("50e3badf-7759-4b27-9c76-6305ac95c1fe"), "Rob", "Reiner" },
                    { new Guid("8f3a8e8c-3199-4348-ae3a-a7c46dcb4619"), "John", "Avildsen" },
                    { new Guid("9a3b6291-6aee-4eac-bb71-a415a5b4611d"), "Clint", "Eastwood" },
                    { new Guid("b9bf3d82-022a-4c18-8e58-788cd20b5a6b"), "Steven", "Spielberg" },
                    { new Guid("bdbb9125-4af7-4b54-b959-612bead99064"), "Other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("4d208541-5881-486c-afe2-59cbbea10532"), "VHS" },
                    { new Guid("60c9acca-26d1-4d8a-8049-91565fb9e37e"), "Other" },
                    { new Guid("f9b4a0b4-eeab-474f-916e-832f82e70d87"), "Blu-Ray" },
                    { new Guid("ffd3b0af-b421-450d-86f1-67135ca742f3"), "DVD" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("04bc70ea-273b-43e0-bacf-d734ad4e15d3"), "Mystery" },
                    { new Guid("4debd424-f6eb-4640-9a1b-71c6d4596c46"), "Action" },
                    { new Guid("646aae24-d4b5-47fd-b7d2-141d8caa69c4"), "Horror" },
                    { new Guid("719de0fd-75d3-45ee-8448-6d7972cdc60b"), "Romance" },
                    { new Guid("789a851b-6030-4abe-b125-959c862a0f58"), "Musical" },
                    { new Guid("9c09a72e-2b91-4a2a-82ad-0eb0e36d909d"), "Comedy" },
                    { new Guid("9c535db9-6376-493e-a2d1-ef4e5418d686"), "Western" },
                    { new Guid("ceece509-7c31-457d-8b9c-9ed2b9a5ccd7"), "Sci-Fi" },
                    { new Guid("e0ba8221-48ad-49a8-af92-45fc3c2abb48"), "Documentary" },
                    { new Guid("eb10643f-0491-4361-802c-265d4cff72eb"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId", "tblCustomerId" },
                values: new object[,]
                {
                    { new Guid("78840159-afbb-43e7-9b5a-139a75f9a464"), new Guid("d0b82509-ef1a-437d-a3cc-c944cbfc03e2"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b1e3451-68fc-418c-8f8c-53fca468510f"), null },
                    { new Guid("791f1778-ad3d-42f3-bdaa-42661204a72d"), new Guid("67c6816d-c550-4572-90c0-40c2196fd524"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("242689f9-8371-48c8-a6d1-4a550b8ced7e"), null },
                    { new Guid("c844d857-aa0d-4f41-9af5-51c5f8b9b108"), new Guid("67c6816d-c550-4572-90c0-40c2196fd524"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b1e3451-68fc-418c-8f8c-53fca468510f"), null }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4964e876-d589-47d1-8802-9ec858572431"), 8.9900000000000002, new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed"), new Guid("78840159-afbb-43e7-9b5a-139a75f9a464"), 0 },
                    { new Guid("549fcfa1-fbe1-4dc8-90d9-b6f21009ab70"), 10.99, new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c"), new Guid("c844d857-aa0d-4f41-9af5-51c5f8b9b108"), 0 },
                    { new Guid("6cedf6f6-b8b0-4d3a-9f7f-811edc0f8860"), 9.9900000000000002, new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c"), new Guid("78840159-afbb-43e7-9b5a-139a75f9a464"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("0135de36-ab7e-4dc2-9723-ce5e85eb7a2d"), "Other" },
                    { new Guid("5014f080-022a-4bc8-93e7-f5764c26c4d8"), "R" },
                    { new Guid("6980bed4-9feb-4b46-80ed-85ee00bfda9c"), "PG-13" },
                    { new Guid("ab395cfc-b037-425b-a015-fe6a21ebd881"), "PG" },
                    { new Guid("b301512a-4f3b-42f4-99c8-c3ce30c4718d"), "G" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("242689f9-8371-48c8-a6d1-4a550b8ced7e"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("3b1e3451-68fc-418c-8f8c-53fca468510f"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("9506e295-178c-40e8-844f-54ef9bb6f99d"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("380bb522-c76f-444c-bbb5-148db08a3ba5"), new Guid("3b1e3451-68fc-418c-8f8c-53fca468510f") },
                    { new Guid("6243a011-04f7-440c-93b7-7fdce551df05"), new Guid("9506e295-178c-40e8-844f-54ef9bb6f99d") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "InStkQty", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("1af1ac16-0984-4d72-8445-f85d0c7a5f62"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("43974b5e-fbb2-4590-93ee-aef621263256"), new Guid("f9b4a0b4-eeab-474f-916e-832f82e70d87"), "IndianaJonesLastCrusade.jpg", 2, new Guid("5014f080-022a-4bc8-93e7-f5764c26c4d8"), "Indiana Jones and the Last Crusade" },
                    { new Guid("1fca65be-9be3-4c52-8b7d-94cb545df6b1"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("b9bf3d82-022a-4c18-8e58-788cd20b5a6b"), new Guid("ffd3b0af-b421-450d-86f1-67135ca742f3"), "StarWarsNewHope.jpg", 1, new Guid("6980bed4-9feb-4b46-80ed-85ee00bfda9c"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("8f3a8e8c-3199-4348-ae3a-a7c46dcb4619"), new Guid("4d208541-5881-486c-afe2-59cbbea10532"), "Rocky.jpg", 2, new Guid("b301512a-4f3b-42f4-99c8-c3ce30c4718d"), "Rocky" },
                    { new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("b9bf3d82-022a-4c18-8e58-788cd20b5a6b"), new Guid("ffd3b0af-b421-450d-86f1-67135ca742f3"), "Jaws1.jpg", 1, new Guid("6980bed4-9feb-4b46-80ed-85ee00bfda9c"), "Jaws" },
                    { new Guid("9dcf9ec0-8914-4efb-a4f5-7b0d999d0290"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("50e3badf-7759-4b27-9c76-6305ac95c1fe"), new Guid("f9b4a0b4-eeab-474f-916e-832f82e70d87"), "PrincessBride.jpg", 4, new Guid("ab395cfc-b037-425b-a015-fe6a21ebd881"), "The Princess Bride" },
                    { new Guid("bed7a1e8-f790-4e49-a8d5-3893bbe59a00"), 6.9900000000000002, "Other", new Guid("8f3a8e8c-3199-4348-ae3a-a7c46dcb4619"), new Guid("4d208541-5881-486c-afe2-59cbbea10532"), "Rocky.jpg", 2, new Guid("b301512a-4f3b-42f4-99c8-c3ce30c4718d"), "Other" },
                    { new Guid("e426f7bf-60c9-472e-a73d-b8203813d702"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("b9bf3d82-022a-4c18-8e58-788cd20b5a6b"), new Guid("ffd3b0af-b421-450d-86f1-67135ca742f3"), "PaleRider.jpg", 1, new Guid("6980bed4-9feb-4b46-80ed-85ee00bfda9c"), "Pale Rider" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("3017df47-30ae-4767-893c-03dcc6b6cef7"), new Guid("6243a011-04f7-440c-93b7-7fdce551df05"), new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed"), 1 },
                    { new Guid("547dd683-43ab-406c-a3f0-7ce25cb298b4"), new Guid("6243a011-04f7-440c-93b7-7fdce551df05"), new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c"), 2 },
                    { new Guid("84d189de-668b-4320-8751-11f0e66a8f5d"), new Guid("380bb522-c76f-444c-bbb5-148db08a3ba5"), new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0a3b358c-2417-43a1-a631-7229177582ef"), new Guid("04bc70ea-273b-43e0-bacf-d734ad4e15d3"), new Guid("e426f7bf-60c9-472e-a73d-b8203813d702") },
                    { new Guid("0e3d0e05-7113-4c34-b7f5-3385e058f5c3"), new Guid("789a851b-6030-4abe-b125-959c862a0f58"), new Guid("1fca65be-9be3-4c52-8b7d-94cb545df6b1") },
                    { new Guid("1726a40d-ba67-435e-8330-7cbf33b4defc"), new Guid("4debd424-f6eb-4640-9a1b-71c6d4596c46"), new Guid("9dcf9ec0-8914-4efb-a4f5-7b0d999d0290") },
                    { new Guid("6a905489-69a5-4a38-8d2c-8ab453ba1660"), new Guid("646aae24-d4b5-47fd-b7d2-141d8caa69c4"), new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed") },
                    { new Guid("7245313d-a82a-439a-8d90-f126e9b69ab6"), new Guid("ceece509-7c31-457d-8b9c-9ed2b9a5ccd7"), new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c") },
                    { new Guid("8d0e35b5-c3a5-4b8f-8308-f4d91df3f3b0"), new Guid("646aae24-d4b5-47fd-b7d2-141d8caa69c4"), new Guid("1fca65be-9be3-4c52-8b7d-94cb545df6b1") },
                    { new Guid("9245a676-c91f-4058-903f-585bf49dd603"), new Guid("646aae24-d4b5-47fd-b7d2-141d8caa69c4"), new Guid("98a25359-07b4-4b07-a533-b3ae2609d06c") },
                    { new Guid("b43e336d-c2fb-45c1-83e6-6fa8aba324dc"), new Guid("e0ba8221-48ad-49a8-af92-45fc3c2abb48"), new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed") },
                    { new Guid("bcc472db-86f6-41e9-aa2d-a3cad984b766"), new Guid("9c09a72e-2b91-4a2a-82ad-0eb0e36d909d"), new Guid("9dcf9ec0-8914-4efb-a4f5-7b0d999d0290") },
                    { new Guid("c7a3d867-54ce-4248-997c-cbe83e1ee29c"), new Guid("e0ba8221-48ad-49a8-af92-45fc3c2abb48"), new Guid("9dcf9ec0-8914-4efb-a4f5-7b0d999d0290") },
                    { new Guid("d6b67385-2784-4b07-bac2-77a927e426b4"), new Guid("e0ba8221-48ad-49a8-af92-45fc3c2abb48"), new Guid("1af1ac16-0984-4d72-8445-f85d0c7a5f62") },
                    { new Guid("d7f7f33d-0059-4da9-966d-e1ba763d712a"), new Guid("646aae24-d4b5-47fd-b7d2-141d8caa69c4"), new Guid("1af1ac16-0984-4d72-8445-f85d0c7a5f62") },
                    { new Guid("f3fc171d-4d55-47d1-8731-34bc6f5a92e0"), new Guid("ceece509-7c31-457d-8b9c-9ed2b9a5ccd7"), new Guid("51692ea9-aeff-40b5-b4ee-9634e87506ed") }
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
