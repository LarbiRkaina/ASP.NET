using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorEntityId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorEntityId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorEntityId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorEntityId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorEntityId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorEntityId1",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorEntityId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorEntityId1",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorEntityId",
                table: "Books",
                column: "AuthorEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorEntityId1",
                table: "Books",
                column: "AuthorEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorEntityId",
                table: "Books",
                column: "AuthorEntityId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorEntityId1",
                table: "Books",
                column: "AuthorEntityId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
