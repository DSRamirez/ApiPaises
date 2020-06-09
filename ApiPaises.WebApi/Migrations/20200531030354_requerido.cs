using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPaises.WebApi.Migrations
{
    public partial class requerido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_provincias_Paises_paisId",
                table: "provincias");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "provincias");

            migrationBuilder.DropColumn(
                name: "NombreProv",
                table: "provincias");

            migrationBuilder.RenameColumn(
                name: "paisId",
                table: "provincias",
                newName: "PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_provincias_paisId",
                table: "provincias",
                newName: "IX_provincias_PaisId");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "provincias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodProv",
                table: "provincias",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomProv",
                table: "provincias",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_provincias_Paises_PaisId",
                table: "provincias",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_provincias_Paises_PaisId",
                table: "provincias");

            migrationBuilder.DropColumn(
                name: "CodProv",
                table: "provincias");

            migrationBuilder.DropColumn(
                name: "NomProv",
                table: "provincias");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "provincias",
                newName: "paisId");

            migrationBuilder.RenameIndex(
                name: "IX_provincias_PaisId",
                table: "provincias",
                newName: "IX_provincias_paisId");

            migrationBuilder.AlterColumn<int>(
                name: "paisId",
                table: "provincias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "provincias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProv",
                table: "provincias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_provincias_Paises_paisId",
                table: "provincias",
                column: "paisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
