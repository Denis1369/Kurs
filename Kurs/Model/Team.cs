using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Team
{
    public int IDteam { get; set; }

    public string Title { get; set; } = null!;

    public string? DescriptionT { get; set; }

    public string? Base { get; set; }

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Racer> Racers { get; set; } = new List<Racer>();
}
