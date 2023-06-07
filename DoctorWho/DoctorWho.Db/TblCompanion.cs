using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblCompanion
{
    public int CompanionId { get; set; }

    public string CompanionName { get; set; } = null!;

    public string? WhoPlayed { get; set; }

    public virtual ICollection<TblEpisodeCompanion> TblEpisodeCompanions { get; set; } = new List<TblEpisodeCompanion>();
}
