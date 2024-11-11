using System;
using System.Collections.Generic;

namespace kutyak.Models;

public partial class Fajtum
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    public virtual ICollection<Kutya> Kutyas { get; set; } = new List<Kutya>();
}
