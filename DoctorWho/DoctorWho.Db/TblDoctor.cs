using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblDoctor
{
    public int DoctorId { get; set; }

    public int DoctorNumber { get; set; }

    public string? DoctorName { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly LastEpisodeDate { get; set; }

    public DateOnly FirstEpisodeDate { get; set; }

    public virtual ICollection<TblEpisode> TblEpisodes { get; set; } = new List<TblEpisode>();
}
