using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Itika.Migrations
{
    public partial class initialmigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Biometrico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometrico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HoraExtra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    fecha_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img_horaextra = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    img_qr = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    codigo_randon = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraExtra", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_entrada1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_salida1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idarea = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carnet_identidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagen_perfil = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    imagen_biometrico = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empleado_Area",
                        column: x => x.idarea,
                        principalTable: "Area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    idrol = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pregunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    respuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intentos = table.Column<int>(type: "int", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol",
                        column: x => x.idrol,
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idtipo = table.Column<int>(type: "int", nullable: false),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    img_permiso = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    img_qr = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    codigo_randon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permiso_Tipo",
                        column: x => x.idtipo,
                        principalTable: "Tipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsignarTurno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idturno = table.Column<int>(type: "int", nullable: false),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    fecha_asignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_asignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignarTurno", x => x.id);
                    table.ForeignKey(
                        name: "FK_AsignarTurno_Turno",
                        column: x => x.idturno,
                        principalTable: "Turno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanillaRecarga",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idempleado = table.Column<int>(type: "int", nullable: false),
                    idpermiso = table.Column<int>(type: "int", nullable: true),
                    fecha_entrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hora_entrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hora_entrada1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hora_salida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hora_salida1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    retraso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    retraso2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado_retraso = table.Column<bool>(type: "bit", nullable: true),
                    recarga_nocturna = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado_recarga_nocturna = table.Column<bool>(type: "bit", nullable: true),
                    feriado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado_feriado = table.Column<bool>(type: "bit", nullable: true),
                    dominical = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado_dominical = table.Column<bool>(type: "bit", nullable: true),
                    estado_falta = table.Column<bool>(type: "bit", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanillaRecarga", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanillaRecarga_Permiso",
                        column: x => x.idpermiso,
                        principalTable: "Permiso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignarTurno_idturno",
                table: "AsignarTurno",
                column: "idturno");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_idarea",
                table: "Empleado",
                column: "idarea");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_idtipo",
                table: "Permiso",
                column: "idtipo");

            migrationBuilder.CreateIndex(
                name: "IX_PlanillaRecarga_idpermiso",
                table: "PlanillaRecarga",
                column: "idpermiso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idrol",
                table: "Usuario",
                column: "idrol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignarTurno");

            migrationBuilder.DropTable(
                name: "Biometrico");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "HoraExtra");

            migrationBuilder.DropTable(
                name: "PlanillaRecarga");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
