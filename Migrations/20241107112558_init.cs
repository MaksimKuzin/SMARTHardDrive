using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMARTHardDrive.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardDrives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CapacityGB = table.Column<int>(type: "int", nullable: false),
                    ConnectionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InstallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Активен")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMARTAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Threshold = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMARTAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertHardDrive",
                columns: table => new
                {
                    AlertsId = table.Column<int>(type: "int", nullable: false),
                    HardDrivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertHardDrive", x => new { x.AlertsId, x.HardDrivesId });
                    table.ForeignKey(
                        name: "FK_AlertHardDrive_Alerts_AlertsId",
                        column: x => x.AlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertHardDrive_HardDrives_HardDrivesId",
                        column: x => x.HardDrivesId,
                        principalTable: "HardDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HardDriveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_HardDrives_HardDriveId",
                        column: x => x.HardDriveId,
                        principalTable: "HardDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMARTData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HardDriveId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMARTData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMARTData_HardDrives_HardDriveId",
                        column: x => x.HardDriveId,
                        principalTable: "HardDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMARTData_SMARTAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "SMARTAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertHardDrive_HardDrivesId",
                table: "AlertHardDrive",
                column: "HardDrivesId");

            migrationBuilder.CreateIndex(
                name: "IX_HardDrives_SerialNumber",
                table: "HardDrives",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_HardDriveId",
                table: "Maintenances",
                column: "HardDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_SMARTData_AttributeId",
                table: "SMARTData",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SMARTData_HardDriveId",
                table: "SMARTData",
                column: "HardDriveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertHardDrive");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "SMARTData");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "HardDrives");

            migrationBuilder.DropTable(
                name: "SMARTAttributes");
        }
    }
}
