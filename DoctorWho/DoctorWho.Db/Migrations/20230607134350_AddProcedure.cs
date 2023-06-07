using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE spSummariseEpisodes
AS
BEGIN
    SELECT EnemyName FROM tblEnemy
    WHERE EnemyID IN
    (
        SELECT TOP(3) EnemyID
        FROM tblEpisodeEnemy
        GROUP BY EnemyID
        ORDER BY COUNT(EpisodeID) DESC  
    );

    SELECT CompanionName FROM tblCompanion
    WHERE CompanionID IN
    (
        SELECT TOP(3) CompanionID
        FROM tblEpisodeCompanion
        GROUP BY CompanionID
        ORDER BY COUNT(EpisodeID) DESC  
    ); 
END; ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE  spSummariseEpisodes");
        }
    }
}
