using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewSchedulingProject1.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidateFullDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenth = table.Column<float>(type: "real", nullable: true),
                    twelth = table.Column<float>(type: "real", nullable: true),
                    graduation = table.Column<float>(type: "real", nullable: true),
                    postgraduation = table.Column<float>(type: "real", nullable: true),
                    skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experince = table.Column<float>(type: "real", nullable: true),
                    selected = table.Column<bool>(type: "bit", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateFullDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateUser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selected = table.Column<bool>(type: "bit", nullable: true),
                    InterviewTiming = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "condidateDetails",
                columns: table => new
                {
                    canditateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenth = table.Column<float>(type: "real", nullable: true),
                    twelth = table.Column<float>(type: "real", nullable: true),
                    graduation = table.Column<float>(type: "real", nullable: true),
                    postgraduation = table.Column<float>(type: "real", nullable: true),
                    skills = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Experince = table.Column<float>(type: "real", nullable: true),
                    Candidateid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condidateDetails", x => x.canditateid);
                    table.ForeignKey(
                        name: "FK_condidateDetails_CandidateUser_Candidateid",
                        column: x => x.Candidateid,
                        principalTable: "CandidateUser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_condidateDetails_Candidateid",
                table: "condidateDetails",
                column: "Candidateid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateFullDetails");

            migrationBuilder.DropTable(
                name: "condidateDetails");

            migrationBuilder.DropTable(
                name: "CandidateUser");
        }
    }
}
