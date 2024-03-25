using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPPF_API.Migrations
{
    /// <inheritdoc />
    public partial class _0325 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "env_record_device_id_fkey",
                table: "env_record");

            migrationBuilder.RenameColumn(
                name: "adress",
                table: "fatek_record",
                newName: "address");

            migrationBuilder.RenameIndex(
                name: "fatek_record_adress_line_time_key",
                table: "fatek_record",
                newName: "fatek_record_address_line_time_key");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId1",
                table: "env_record",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "scale_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    line = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("scale_record_pkey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "fatek_record_address_line_time_idx",
                table: "fatek_record",
                columns: new[] { "address", "line", "time" });

            migrationBuilder.CreateIndex(
                name: "IX_env_record_DeviceId1",
                table: "env_record",
                column: "DeviceId1");

            migrationBuilder.CreateIndex(
                name: "scale_record_address_line_time_idx",
                table: "scale_record",
                columns: new[] { "address", "line", "time" });

            migrationBuilder.CreateIndex(
                name: "scale_record_address_line_time_key",
                table: "scale_record",
                columns: new[] { "address", "line", "time" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_env_record_device_DeviceId1",
                table: "env_record",
                column: "DeviceId1",
                principalTable: "device",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_env_record_device_DeviceId1",
                table: "env_record");

            migrationBuilder.DropTable(
                name: "scale_record");

            migrationBuilder.DropIndex(
                name: "fatek_record_address_line_time_idx",
                table: "fatek_record");

            migrationBuilder.DropIndex(
                name: "IX_env_record_DeviceId1",
                table: "env_record");

            migrationBuilder.DropColumn(
                name: "DeviceId1",
                table: "env_record");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "fatek_record",
                newName: "adress");

            migrationBuilder.RenameIndex(
                name: "fatek_record_address_line_time_key",
                table: "fatek_record",
                newName: "fatek_record_adress_line_time_key");

            migrationBuilder.AddForeignKey(
                name: "env_record_device_id_fkey",
                table: "env_record",
                column: "device_id",
                principalTable: "device",
                principalColumn: "device_id");
        }
    }
}
