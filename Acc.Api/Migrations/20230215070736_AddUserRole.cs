using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OjasTech.Acc.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_role_id",
                table: "account_users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 0, "Normal User", "User" },
                    { 1000, "Admin User", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_users_user_role_id",
                table: "account_users",
                column: "user_role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_users_user_roles_user_role_id",
                table: "account_users",
                column: "user_role_id",
                principalTable: "user_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_users_user_roles_user_role_id",
                table: "account_users");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropIndex(
                name: "ix_account_users_user_role_id",
                table: "account_users");

            migrationBuilder.DropColumn(
                name: "user_role_id",
                table: "account_users");
        }
    }
}
