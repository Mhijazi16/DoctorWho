using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblEpisode
{
    public int EpisodeId { get; set; }

    public int SeriesNumber { get; set; }

    public short EpisodeNumber { get; set; }

    public string? EpisodeType { get; set; }

    public string? Title { get; set; }

    public DateOnly EpisodeDate { get; set; }

    public int? AuthorId { get; set; }

    public int? DoctorId { get; set; }

    public string? Notes { get; set; }

    public virtual TblAuthor? Author { get; set; }

    public virtual TblDoctor? Doctor { get; set; }

    public virtual ICollection<TblEpisodeCompanion> TblEpisodeCompanions { get; set; } = new List<TblEpisodeCompanion>();

    public virtual ICollection<TblEpisodeEnemy> TblEpisodeEnemies { get; set; } = new List<TblEpisodeEnemy>();
}
