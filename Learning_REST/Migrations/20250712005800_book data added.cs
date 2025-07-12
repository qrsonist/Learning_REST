using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Learning_REST.Migrations
{
    /// <inheritdoc />
    public partial class bookdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genres", "NumPages", "Subtitle", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Follett, Ken", "[\"Historical Fiction\"]", 806, null, "The Pillars of the Earth", 1989 },
                    { 2, "Le Guin, Ursula K.", "[\"Science Fiction\"]", 286, null, "The Left Hand of Darkness", 1969 },
                    { 3, "Flynn, Gillian", "[\"Psychological Thriller\",\"Southern Gothic\",\"Mystery\"]", 0, null, "Sharp Objects", 2006 },
                    { 4, "Jemisin, N. K.", "[\"Science Fantasy\"]", 512, null, "The Fifth Season", 2015 },
                    { 5, "Isaacson, Walter", "[\"Biography\"]", 656, null, "Steve Jobs", 2011 },
                    { 6, "Moyes, Jojo", "[\"Romance\",\"Fiction\"]", 480, null, "Me Before You", 2012 },
                    { 7, "Stearns, Marshall W.", "[\"Music\",\"History\",\"Nonfiction\"]", 367, null, "The Story of Jazz", 1970 },
                    { 8, "King, Stephen", "[\"Horror\",\"Thriller\",\"Dark Fantasy\"]", 1138, null, "It", 1986 },
                    { 9, "Dugoni, Robert", "[\"Historical Fiction\"]", 448, null, "The Extraordinary Life of Sam Hell", 2018 },
                    { 10, "Livio, Mario", "[\"Science\",\"Nonfiction\",\"Mathematics\",\"History\",\"Philosophy\"]", 294, "The Story of Phi, the World's Most Astonishing Number", "The Golden Ratio", 2002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
