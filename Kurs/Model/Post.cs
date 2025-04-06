using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Post
{
    public int IDpost { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
}
