using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PhoneBook.DAL.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    text_comment = table.Column<string>(type: "text", nullable: false),
                    contact_type_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_contact_contact_types_contact_type_id",
                        column: x => x.contact_type_id,
                        principalTable: "ContactType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    contact_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrivateOrganization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    organization_type = table.Column<string>(type: "text", nullable: false),
                    tax_id = table.Column<string>(type: "text", nullable: false),
                    contact_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_private_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_private_organization_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicOrganization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    website = table.Column<string>(type: "text", nullable: false),
                    public_info = table.Column<string>(type: "text", nullable: false),
                    contact_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_public_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_public_organization_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date", "name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(681), false, null, "Person" },
                    { 2L, new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(700), false, null, "Private organization" },
                    { 3L, new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(706), false, null, "Public organization" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_contact_contact_type_id",
                table: "Contact",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_contact_created_date",
                table: "Contact",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_contact_is_deleted",
                table: "Contact",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_contact_type_created_date",
                table: "ContactType",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_contact_type_is_deleted",
                table: "ContactType",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_person_contact_id",
                table: "Person",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_created_date",
                table: "Person",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_person_is_deleted",
                table: "Person",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_private_organization_contact_id",
                table: "PrivateOrganization",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_private_organization_created_date",
                table: "PrivateOrganization",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_private_organization_is_deleted",
                table: "PrivateOrganization",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_public_organization_contact_id",
                table: "PublicOrganization",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_public_organization_created_date",
                table: "PublicOrganization",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_public_organization_is_deleted",
                table: "PublicOrganization",
                column: "is_deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PrivateOrganization");

            migrationBuilder.DropTable(
                name: "PublicOrganization");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactType");
        }
    }
}
