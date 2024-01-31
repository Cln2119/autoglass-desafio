using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataFabricacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataValidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoFornecedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescricaoFornecedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CnpjFornecedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
