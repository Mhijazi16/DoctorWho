using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class Episode
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

    public virtual Author? Author { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<EpisodeCompanion> TblEpisodeCompanions { get; set; } = new List<EpisodeCompanion>();

    public virtual ICollection<EpisodeEnemy> TblEpisodeEnemies { get; set; } = new List<EpisodeEnemy>();
}
