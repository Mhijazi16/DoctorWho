using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class Enemy
{
    public int EnemyId { get; set; }

    public string EnemyName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<EpisodeEnemy> TblEpisodeEnemies { get; set; } = new List<EpisodeEnemy>();
}
