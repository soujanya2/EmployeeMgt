using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMgmt.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deptid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Deptid",
                        column: x => x.Deptid,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_deptid",
                        column: x => x.deptid,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empemail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_empemail",
                        column: x => x.empemail,
                        principalTable: "Employees",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_pid",
                        column: x => x.pid,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_empemail",
                table: "EmployeeProjects",
                column: "empemail");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_pid",
                table: "EmployeeProjects",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Deptid",
                table: "Employees",
                column: "Deptid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_deptid",
                table: "Projects",
                column: "deptid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
