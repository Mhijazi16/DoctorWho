using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fnEnemies (@episodeID INT)
RETURNS VARCHAR(MAX)
BEGIN
    DECLARE @names VARCHAR(MAX); 
    SELECT @names = CONCAT_WS(', ',@names, EnemyName)
    FROM tblEnemy
    WHERE EnemyID IN (
        SELECT EnemyID FROM tblEpisodeEnemy
        WHERE @episodeID = tblEpisodeEnemy.EpisodeID
    )
RETURN @names
END;");
            migrationBuilder.Sql(@"CREATE FUNCTION fnCompanions (@episodeID INT)
RETURNS VARCHAR(MAX)
BEGIN 
    DECLARE @names VARCHAR(MAX)

    SELECT @names = CONCAT_WS(', ' , @names, CompanionName)
    FROM tblCompanion
    WHERE tblCompanion.CompanionID  IN 
    ( 
        SELECT CompanionID FROM tblEpisodeCompanion AS ec
        WHERE @episodeID = ec.EpisodeID 
    );
RETURN @names;
END;"); 
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.fnCompanions;");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemies;");
        }
    }
}
