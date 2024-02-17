using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcDay2.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Dnum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mgssn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Dnum);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Ssn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<DateOnly>(type: "date", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "money", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dno = table.Column<int>(type: "int", nullable: true),
                    superid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Ssn);
                    table.ForeignKey(
                        name: "FK_employees_departments_Dno",
                        column: x => x.Dno,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                    table.ForeignKey(
                        name: "FK_employees_employees_superid",
                        column: x => x.superid,
                        principalTable: "employees",
                        principalColumn: "Ssn");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_departments_Dno",
                        column: x => x.Dno,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    eSsn = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => new { x.name, x.eSsn });
                    table.ForeignKey(
                        name: "FK_dependents_employees_eSsn",
                        column: x => x.eSsn,
                        principalTable: "employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "work_Fors",
                columns: table => new
                {
                    eSsn = table.Column<int>(type: "int", nullable: false),
                    pno = table.Column<int>(type: "int", nullable: false),
                    Houres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_Fors", x => new { x.eSsn, x.pno });
                    table.ForeignKey(
                        name: "FK_work_Fors_employees_eSsn",
                        column: x => x.eSsn,
                        principalTable: "employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_work_Fors_projects_pno",
                        column: x => x.pno,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_Mgssn",
                table: "departments",
                column: "Mgssn",
                unique: true,
                filter: "[Mgssn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_eSsn",
                table: "dependents",
                column: "eSsn");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Dno",
                table: "employees",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_employees_superid",
                table: "employees",
                column: "superid");

            migrationBuilder.CreateIndex(
                name: "IX_projects_Dno",
                table: "projects",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_work_Fors_pno",
                table: "work_Fors",
                column: "pno");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_employees_Mgssn",
                table: "departments",
                column: "Mgssn",
                principalTable: "employees",
                principalColumn: "Ssn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_employees_Mgssn",
                table: "departments");

            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "work_Fors");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
