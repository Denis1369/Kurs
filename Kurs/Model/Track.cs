using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Track
{
    public int IDtrack { get; set; }

    public string Title { get; set; } = null!;

    public string Place { get; set; } = null!;

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
