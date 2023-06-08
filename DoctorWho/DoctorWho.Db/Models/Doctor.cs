using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public int DoctorNumber { get; set; }

    public string? DoctorName { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly LastEpisodeDate { get; set; }

    public DateOnly FirstEpisodeDate { get; set; }

    public virtual ICollection<Episode> TblEpisodes { get; set; } = new List<Episode>();
}
