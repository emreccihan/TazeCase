using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazeCase.Form.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFormDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormDataValues_FormData_FormDataId",
                table: "FormDataValues");

            migrationBuilder.DropTable(
                name: "FormData");

            migrationBuilder.RenameColumn(
                name: "FormDataId",
                table: "FormDataValues",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_FormDataValues_FormDataId",
                table: "FormDataValues",
                newName: "IX_FormDataValues_FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormDataValues_Forms_FormId",
                table: "FormDataValues",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormDataValues_Forms_FormId",
                table: "FormDataValues");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "FormDataValues",
                newName: "FormDataId");

            migrationBuilder.RenameIndex(
                name: "IX_FormDataValues_FormId",
                table: "FormDataValues",
                newName: "IX_FormDataValues_FormDataId");

            migrationBuilder.CreateTable(
                name: "FormData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormData_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormData_FormId",
                table: "FormData",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormDataValues_FormData_FormDataId",
                table: "FormDataValues",
                column: "FormDataId",
                principalTable: "FormData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
