using System;
using System.Collections.Generic;

namespace DoctorWho.Db;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Episode> TblEpisodes { get; set; } = new List<Episode>();
}
