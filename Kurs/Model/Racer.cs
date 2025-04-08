using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Racer
{
    public int IDracer { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string PlaceOfBirth { get; set; } = null!;

    public int? IDteam { get; set; }

    public virtual Team? IDteamNavigation { get; set; }

    public string Fam => (LastName.Substring(0,3).ToUpper());

    public virtual ICollection<RacingResult> RacingResults { get; set; } = new List<RacingResult>();

}
