using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class ViewEpisode
{
    public int EpisodeId { get; set; }

    public int? AuthorId { get; set; }

    public int? DoctorId { get; set; }

    public string? Title { get; set; }

    public string? AuthorName { get; set; }

    public string? DoctorName { get; set; }

    public int SeriesNumber { get; set; }

    public string? Enemies { get; set; }

    public string? Companions { get; set; }

    public short EpisodeNumber { get; set; }

    public string? EpisodeType { get; set; }

    public DateOnly EpisodeDate { get; set; }

    public string? Notes { get; set; }
}
