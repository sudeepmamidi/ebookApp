using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApp.Migrations
{
    public partial class BookCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksTable",
                columns: table => new
                {
                    Bookid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookname = table.Column<string>(nullable: false),
                    Bookauthor = table.Column<string>(nullable: false),
                    Bookdescription = table.Column<string>(nullable: false),
                    price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksTable", x => x.Bookid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksTable");
        }
    }
}
