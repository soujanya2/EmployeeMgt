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
                name: "Department",
                columns: table => new
                {
                    deptid = table.Column<int>(type: "int", nullable: false),
                    deptname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__BE2C1AEE0FD3BC4E", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    empId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    Phoneno = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Manager = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Date_of_joining = table.Column<DateTime>(type: "datetime", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__A9D10535B7F162A6", x => x.Email);
                    table.ForeignKey(
                        name: "FK__Employee__dept_i__4E88ABD4",
                        column: x => x.dept_id,
                        principalTable: "Department",
                        principalColumn: "deptid");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    projectid = table.Column<int>(type: "int", nullable: false),
                    projectname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    duration = table.Column<DateTime>(type: "datetime", nullable: true),
                    did = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__11EC39DD241AF5D9", x => x.projectid);
                    table.ForeignKey(
                        name: "FK__Project__did__4BAC3F29",
                        column: x => x.did,
                        principalTable: "Department",
                        principalColumn: "deptid");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    epid = table.Column<int>(type: "int", nullable: false),
                    empemail = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    proj_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3AF3FC78E77C9768", x => x.epid);
                    table.ForeignKey(
                        name: "FK__EmployeeP__empem__5165187F",
                        column: x => x.empemail,
                        principalTable: "Employee",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK__EmployeeP__proj___52593CB8",
                        column: x => x.proj_id,
                        principalTable: "Project",
                        principalColumn: "projectid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_dept_id",
                table: "Employee",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_empemail",
                table: "EmployeeProjects",
                column: "empemail");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_proj_id",
                table: "EmployeeProjects",
                column: "proj_id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_did",
                table: "Project",
                column: "did");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
