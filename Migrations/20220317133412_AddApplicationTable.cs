using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dn6.Migrations
{
    public partial class AddApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    uid = table.Column<string>(type: "text", nullable: true),
                    last_update = table.Column<string>(type: "text", nullable: true),
                    application_category = table.Column<int>(type: "integer", nullable: false),
                    publisher = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    version = table.Column<string>(type: "text", nullable: true),
                    copyright = table.Column<string>(type: "text", nullable: true),
                    license_accept_required = table.Column<bool>(type: "boolean", nullable: false),
                    cpu_arch = table.Column<int>(type: "integer", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: true),
                    sha256 = table.Column<string>(type: "text", nullable: true),
                    follow_uri = table.Column<string>(type: "text", nullable: true),
                    absolute_uri = table.Column<string>(type: "text", nullable: true),
                    switches = table.Column<string>(type: "text", nullable: true),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    display_publisher = table.Column<string>(type: "text", nullable: true),
                    display_version = table.Column<string>(type: "text", nullable: true),
                    detect_method = table.Column<int>(type: "integer", nullable: false),
                    detect_script = table.Column<string>(type: "text", nullable: true),
                    detect_value = table.Column<string>(type: "text", nullable: true),
                    uninstall_method = table.Column<int>(type: "integer", nullable: false),
                    uninstall_cmd = table.Column<string>(type: "text", nullable: true),
                    uninstall_args = table.Column<string>(type: "text", nullable: true),
                    homepage = table.Column<string>(type: "text", nullable: true),
                    icon = table.Column<string>(type: "text", nullable: true),
                    docs = table.Column<string>(type: "text", nullable: true),
                    license = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string[]>(type: "text[]", nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    reboot_required = table.Column<bool>(type: "boolean", nullable: false),
                    lcid = table.Column<int>(type: "integer", nullable: false),
                    xft_code = table.Column<int>(type: "integer", nullable: false),
                    locale = table.Column<int>(type: "integer", nullable: false),
                    repo = table.Column<string>(type: "text", nullable: true),
                    uri_path = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    depends_on = table.Column<string[]>(type: "text[]", nullable: true),
                    virus_total_scan_results_id = table.Column<int>(type: "integer", nullable: true),
                    exploit_report_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applications", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_applications_uuid_uid",
                table: "applications",
                columns: new[] { "uuid", "uid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");
        }
    }
}
