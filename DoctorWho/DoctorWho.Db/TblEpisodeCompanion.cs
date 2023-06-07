﻿using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblEpisodeCompanion
{
    public int EpisodeCompanionId { get; set; }

    public int? EpisodeId { get; set; }

    public int? CompanionId { get; set; }

    public virtual TblCompanion? Companion { get; set; }

    public virtual TblEpisode? Episode { get; set; }
}
