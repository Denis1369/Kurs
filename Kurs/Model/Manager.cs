using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Manager
{
    public int IDmanager { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? IDpost { get; set; }

    public int? IDteam { get; set; }

    public virtual Post? IDpostNavigation { get; set; }

    public virtual Team? IDteamNavigation { get; set; }
}
