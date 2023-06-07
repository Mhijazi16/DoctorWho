using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class TblAuthor
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<TblEpisode> TblEpisodes { get; set; } = new List<TblEpisode>();
}
