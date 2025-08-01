using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TAREFA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "datetime", nullable: false),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false),
                    CATEGORIA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAREFA_CATEGORIA_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_NOME",
                table: "CATEGORIA",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_CATEGORIA_ID",
                table: "TAREFA",
                column: "CATEGORIA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAREFA");

            migrationBuilder.DropTable(
                name: "CATEGORIA");
        }
    }
}
