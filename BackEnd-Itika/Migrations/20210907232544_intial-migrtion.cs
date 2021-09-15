using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Itika.Migrations
{
    public partial class intialmigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanillaRecarga_Permiso",
                table: "PlanillaRecarga");

            migrationBuilder.DropIndex(
                name: "IX_PlanillaRecarga_idpermiso",
                table: "PlanillaRecarga");

            migrationBuilder.DropColumn(
                name: "idpermiso",
                table: "PlanillaRecarga");

            migrationBuilder.AddColumn<int>(
                name: "idplanillarecarga",
                table: "Permiso",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanillaRecarga_idempleado",
                table: "PlanillaRecarga",
                column: "idempleado");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_idplanillarecarga",
                table: "Permiso",
                column: "idplanillarecarga");

            migrationBuilder.AddForeignKey(
                name: "FK_Permiso_PlanillaRecarga",
                table: "Permiso",
                column: "idplanillarecarga",
                principalTable: "PlanillaRecarga",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanillaRecarga_Empleado",
                table: "PlanillaRecarga",
                column: "idempleado",
                principalTable: "Empleado",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permiso_PlanillaRecarga",
                table: "Permiso");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanillaRecarga_Empleado",
                table: "PlanillaRecarga");

            migrationBuilder.DropIndex(
                name: "IX_PlanillaRecarga_idempleado",
                table: "PlanillaRecarga");

            migrationBuilder.DropIndex(
                name: "IX_Permiso_idplanillarecarga",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "idplanillarecarga",
                table: "Permiso");

            migrationBuilder.AddColumn<int>(
                name: "idpermiso",
                table: "PlanillaRecarga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanillaRecarga_idpermiso",
                table: "PlanillaRecarga",
                column: "idpermiso");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanillaRecarga_Permiso",
                table: "PlanillaRecarga",
                column: "idpermiso",
                principalTable: "Permiso",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
