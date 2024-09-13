using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazeCase.Form.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFormDataTableForField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "FormDataValues");

            migrationBuilder.AddColumn<Guid>(
                name: "FormFieldId",
                table: "FormDataValues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FormDataValues_FormFieldId",
                table: "FormDataValues",
                column: "FormFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormDataValues_FormFields_FormFieldId",
                table: "FormDataValues",
                column: "FormFieldId",
                principalTable: "FormFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormDataValues_FormFields_FormFieldId",
                table: "FormDataValues");

            migrationBuilder.DropIndex(
                name: "IX_FormDataValues_FormFieldId",
                table: "FormDataValues");

            migrationBuilder.DropColumn(
                name: "FormFieldId",
                table: "FormDataValues");

            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "FormDataValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
