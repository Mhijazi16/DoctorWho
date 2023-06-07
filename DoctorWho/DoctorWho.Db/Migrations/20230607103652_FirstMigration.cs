using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAuthor",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblAutho__70DAFC14745C864A", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "tblCompanion",
                columns: table => new
                {
                    CompanionID = table.Column<int>(type: "int", nullable: false),
                    CompanionName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    WhoPlayed = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCompa__8B53BE8B2BED7BDE", x => x.CompanionID);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false),
                    DoctorName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastEpisodeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstEpisodeDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblDocto__2DC00EDF6E1BB984", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "tblEnemy",
                columns: table => new
                {
                    EnemyID = table.Column<int>(type: "int", nullable: false),
                    EnemyName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEnemy__911A0BD2AC4B36E9", x => x.EnemyID);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisode",
                columns: table => new
                {
                    EpisodeID = table.Column<int>(type: "int", nullable: false),
                    SeriesNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<short>(type: "smallint", nullable: false),
                    EpisodeType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Title = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    EpisodeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEpiso__AC66761511820723", x => x.EpisodeID);
                    table.ForeignKey(
                        name: "FK__tblEpisod__Autho__2B3F6F97",
                        column: x => x.AuthorID,
                        principalTable: "tblAuthor",
                        principalColumn: "AuthorID");
                    table.ForeignKey(
                        name: "FK__tblEpisod__Docto__2C3393D0",
                        column: x => x.DoctorID,
                        principalTable: "tblDoctor",
                        principalColumn: "DoctorID");
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeCompanion",
                columns: table => new
                {
                    EpisodeCompanionID = table.Column<int>(type: "int", nullable: false),
                    EpisodeID = table.Column<int>(type: "int", nullable: true),
                    CompanionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEpiso__774F3833F16FC7C1", x => x.EpisodeCompanionID);
                    table.ForeignKey(
                        name: "FK__tblEpisod__Compa__398D8EEE",
                        column: x => x.CompanionID,
                        principalTable: "tblCompanion",
                        principalColumn: "CompanionID");
                    table.ForeignKey(
                        name: "FK__tblEpisod__Episo__38996AB5",
                        column: x => x.EpisodeID,
                        principalTable: "tblEpisode",
                        principalColumn: "EpisodeID");
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeEnemy",
                columns: table => new
                {
                    EpisodeEnemyID = table.Column<int>(type: "int", nullable: false),
                    EpisodeID = table.Column<int>(type: "int", nullable: true),
                    EnemyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEpiso__6DF24E50BD88F397", x => x.EpisodeEnemyID);
                    table.ForeignKey(
                        name: "FK__tblEpisod__Enemy__3D5E1FD2",
                        column: x => x.EnemyID,
                        principalTable: "tblEnemy",
                        principalColumn: "EnemyID");
                    table.ForeignKey(
                        name: "FK__tblEpisod__Episo__3C69FB99",
                        column: x => x.EpisodeID,
                        principalTable: "tblEpisode",
                        principalColumn: "EpisodeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_AuthorID",
                table: "tblEpisode",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_DoctorID",
                table: "tblEpisode",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeCompanion_CompanionID",
                table: "tblEpisodeCompanion",
                column: "CompanionID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeCompanion_EpisodeID",
                table: "tblEpisodeCompanion",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeEnemy_EnemyID",
                table: "tblEpisodeEnemy",
                column: "EnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeEnemy_EpisodeID",
                table: "tblEpisodeEnemy",
                column: "EpisodeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEpisodeCompanion");

            migrationBuilder.DropTable(
                name: "tblEpisodeEnemy");

            migrationBuilder.DropTable(
                name: "tblCompanion");

            migrationBuilder.DropTable(
                name: "tblEnemy");

            migrationBuilder.DropTable(
                name: "tblEpisode");

            migrationBuilder.DropTable(
                name: "tblAuthor");

            migrationBuilder.DropTable(
                name: "tblDoctor");
        }
    }
}
