using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes AS
SELECT e.EpisodeID, e.AuthorID, e.DoctorID, e.Title, a.AuthorName, d.DoctorName, e.SeriesNumber, 
                dbo.fnEnemies(e.EpisodeID) AS Enemies, dbo.fnCompanions(e.EpisodeID) AS Companions,
                 e.EpisodeNumber,e.EpisodeType, e.EpisodeDate, e.Notes
FROM tblEpisode e
LEFT JOIN tblDoctor d ON e.DoctorID = d.DoctorID
LEFT JOIN tblAuthor a ON e.AuthorID = a.AuthorID;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.viewEpisodes;");
        }
    }
}
