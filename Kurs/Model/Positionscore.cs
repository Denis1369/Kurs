using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Positionscore
{
    public string Position { get; set; } = null!;

    public int? Score { get; set; }

    public virtual ICollection<RacingResult> RacingResults { get; set; } = new List<RacingResult>();
}
