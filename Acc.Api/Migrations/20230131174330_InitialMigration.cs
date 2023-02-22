using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OjasTech.Acc.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: false),
                    middlename = table.Column<string>(name: "middle_name", type: "text", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account_users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accountid = table.Column<Guid>(name: "account_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_users_accounts_account_id",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_users_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_users_account_id",
                table: "account_users",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_users_user_id",
                table: "account_users",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_users");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
