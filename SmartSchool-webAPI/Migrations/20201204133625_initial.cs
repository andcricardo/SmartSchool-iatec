using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool_webAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tipo = table.Column<string>(type: "TEXT", nullable: true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    dataevento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    local = table.Column<string>(type: "TEXT", nullable: true),
                    participantes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    senha = table.Column<string>(type: "TEXT", nullable: true),
                    datanascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sexo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    decricao = table.Column<string>(type: "TEXT", nullable: true),
                    dataagenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: true),
                    eventoid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agendas_Eventos_eventoid",
                        column: x => x.eventoid,
                        principalTable: "Eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "datanascimento", "email", "nome", "senha", "sexo" },
                values: new object[] { 1, new DateTime(2016, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "contato@andrericardo.eti.br", "André", "123", "Masculino" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_eventoid",
                table: "Agendas",
                column: "eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_usuarioid",
                table: "Agendas",
                column: "usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
