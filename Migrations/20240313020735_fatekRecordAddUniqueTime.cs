using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPPF_API.Migrations
{
    /// <inheritdoc />
    public partial class fatekRecordAddUniqueTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_prisma_migrations",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    checksum = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    finished_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    migration_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    logs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rolled_back_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    started_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    applied_steps_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___prisma___3213E83FFB700BD3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "connection_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("connection_status_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("department_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fatek_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    line = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("fatek_record_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "solid_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solid = table.Column<double>(type: "float", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("solid_record_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationToken",
                columns: table => new
                {
                    identifier = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    token = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "viscosity_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    viscosity = table.Column<double>(type: "float", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("viscosity_record_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    order_name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    status = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    line = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    number = table.Column<double>(type: "float", nullable: false),
                    product_number = table.Column<double>(type: "float", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("work_orders_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    line = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    office_group = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("device_pkey", x => x.id);
                    table.UniqueConstraint("AK_device_device_id", x => x.device_id);
                    table.ForeignKey(
                        name: "device_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    emailVerified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pkey", x => x.id);
                    table.ForeignKey(
                        name: "User_department_id_fkey",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "alarm_setting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    max = table.Column<double>(type: "float", nullable: true),
                    min = table.Column<double>(type: "float", nullable: true),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("alarm_setting_pkey", x => x.id);
                    table.ForeignKey(
                        name: "alarm_setting_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "env_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    humidity = table.Column<double>(type: "float", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("env_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "env_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "operator_record",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("operator_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "operator_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "plc_setting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ip = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    type = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    protocol = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    second = table.Column<double>(type: "float", nullable: false),
                    enable = table.Column<bool>(type: "bit", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("plc_setting_pkey", x => x.id);
                    table.ForeignKey(
                        name: "plc_setting_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "setting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("setting_pkey", x => x.id);
                    table.ForeignKey(
                        name: "setting_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "speed_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speed = table.Column<double>(type: "float", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("speed_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "speed_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "voc_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voc = table.Column<double>(type: "float", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("voc_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "voc_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "weight_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weight = table.Column<double>(type: "float", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("weight_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "weight_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "wmv_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    product_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("wmv_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "wmv_record_device_id_fkey",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "device_id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    userId = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    type = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    provider = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    providerAccountId = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    access_token = table.Column<string>(type: "text", nullable: true),
                    expires_at = table.Column<int>(type: "int", nullable: true),
                    token_type = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    scope = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    id_token = table.Column<string>(type: "text", nullable: true),
                    session_state = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Account_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Account_userId_fkey",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    sessionToken = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    userId = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Session_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Session_userId_fkey",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alarm_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alarm_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    duration = table.Column<double>(type: "float", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("alarm_record_pkey", x => x.id);
                    table.ForeignKey(
                        name: "alarm_record_alarm_id_fkey",
                        column: x => x.alarm_id,
                        principalTable: "alarm_setting",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "Account_provider_providerAccountId_key",
                table: "Account",
                columns: new[] { "provider", "providerAccountId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Account_userId_idx",
                table: "Account",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "alarm_record_alarm_id_idx",
                table: "alarm_record",
                column: "alarm_id");

            migrationBuilder.CreateIndex(
                name: "alarm_setting_device_id_idx",
                table: "alarm_setting",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "device_category_id_idx",
                table: "device",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "device_device_id_key",
                table: "device",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "env_record_device_id_idx",
                table: "env_record",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "fatek_record_adress_line_time_key",
                table: "fatek_record",
                columns: new[] { "adress", "line", "time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "operator_record_device_id_idx",
                table: "operator_record",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "plc_setting_device_id_idx",
                table: "plc_setting",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "Session_sessionToken_key",
                table: "Session",
                column: "sessionToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Session_userId_idx",
                table: "Session",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "setting_device_id_idx",
                table: "setting",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "speed_record_device_id_idx",
                table: "speed_record",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_department_id",
                table: "User",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "User_email_key",
                table: "User",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "VerificationToken_identifier_token_key",
                table: "VerificationToken",
                columns: new[] { "identifier", "token" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "VerificationToken_token_key",
                table: "VerificationToken",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "voc_record_device_id_idx",
                table: "voc_record",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "weight_record_device_id_idx",
                table: "weight_record",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "wmv_record_device_id_idx",
                table: "wmv_record",
                column: "device_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_prisma_migrations");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "alarm_record");

            migrationBuilder.DropTable(
                name: "connection_status");

            migrationBuilder.DropTable(
                name: "env_record");

            migrationBuilder.DropTable(
                name: "fatek_record");

            migrationBuilder.DropTable(
                name: "operator_record");

            migrationBuilder.DropTable(
                name: "plc_setting");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "setting");

            migrationBuilder.DropTable(
                name: "solid_record");

            migrationBuilder.DropTable(
                name: "speed_record");

            migrationBuilder.DropTable(
                name: "VerificationToken");

            migrationBuilder.DropTable(
                name: "viscosity_record");

            migrationBuilder.DropTable(
                name: "voc_record");

            migrationBuilder.DropTable(
                name: "weight_record");

            migrationBuilder.DropTable(
                name: "wmv_record");

            migrationBuilder.DropTable(
                name: "work_orders");

            migrationBuilder.DropTable(
                name: "alarm_setting");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "device");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
