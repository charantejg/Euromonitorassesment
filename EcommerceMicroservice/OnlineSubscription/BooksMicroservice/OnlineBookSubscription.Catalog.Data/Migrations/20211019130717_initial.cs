using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookSubscription.Catalog.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Isbn", "Price", "Thumbnail", "Title" },
                values: new object[,]
                {
                    { 1, "Microsoft", "10001", 150.0, "Ad.png", "Azure" },
                    { 2, "Bob Jane", "10002", 250.0, "cg.png", "Computer Graphics" },
                    { 3, "Martin", "10003", 150.0, "csharp.png", "C Sharp" },
                    { 4, "Peter", "10004", 120.0, "java.png", "Java" },
                    { 5, "Microsoft", "10005", 180.0, "ml.png", "Machine learning" },
                    { 6, "Carlos", "10006", 220.0, "python.png", "Python" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
