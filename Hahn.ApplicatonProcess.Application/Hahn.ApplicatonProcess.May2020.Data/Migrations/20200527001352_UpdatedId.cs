using Microsoft.EntityFrameworkCore.Migrations;

namespace Hahn.ApplicatonProcess.May2020.Data.Migrations
{
    public partial class UpdatedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Applicant",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applicant",
                newName: "ID");
        }
    }
}
