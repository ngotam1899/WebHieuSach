using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Data.Migrations
{
    public partial class AddBookTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublishersID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sources_SourcesID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorsID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishersID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SourcesID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorsID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishersID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SourcesID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookTypeID",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Books",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeID",
                table: "Books",
                column: "BookTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books",
                column: "BookTypeID",
                principalTable: "BookTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherID",
                table: "Books",
                column: "PublisherID",
                principalTable: "Publishers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherID",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypeID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookTypeID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorsID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishersID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourcesID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorsID",
                table: "Books",
                column: "AuthorsID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishersID",
                table: "Books",
                column: "PublishersID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SourcesID",
                table: "Books",
                column: "SourcesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsID",
                table: "Books",
                column: "AuthorsID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublishersID",
                table: "Books",
                column: "PublishersID",
                principalTable: "Publishers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sources_SourcesID",
                table: "Books",
                column: "SourcesID",
                principalTable: "Sources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
