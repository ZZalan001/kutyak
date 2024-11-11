using System;
using System.Collections.Generic;

namespace kutyak.Models;

public partial class Telepulesek
{
    public int Irszam { get; set; }

    public string Telepules { get; set; } = null!;

    public virtual ICollection<Gazdum> Gazda { get; set; } = new List<Gazdum>();
}
