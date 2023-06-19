using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassTransit.SingUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CreditCards_CreditCardId",
                schema: "SingUp",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CreditCards",
                schema: "SingUp");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreditCardId",
                schema: "SingUp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                schema: "SingUp",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreditCardId",
                schema: "SingUp",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                schema: "SingUp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreditCardId",
                schema: "SingUp",
                table: "Users",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CreditCards_CreditCardId",
                schema: "SingUp",
                table: "Users",
                column: "CreditCardId",
                principalSchema: "SingUp",
                principalTable: "CreditCards",
                principalColumn: "Id");
        }
    }
}
