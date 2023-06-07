using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblEnemy
{
    public int EnemyId { get; set; }

    public string EnemyName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TblEpisodeEnemy> TblEpisodeEnemies { get; set; } = new List<TblEpisodeEnemy>();
}
