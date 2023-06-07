﻿using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblEpisodeEnemy
{
    public int EpisodeEnemyId { get; set; }

    public int? EpisodeId { get; set; }

    public int? EnemyId { get; set; }

    public virtual TblEnemy? Enemy { get; set; }

    public virtual TblEpisode? Episode { get; set; }
}
