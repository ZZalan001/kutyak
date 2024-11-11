using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace kutyak.Models;

public partial class Gazdum
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int Irszam { get; set; }

    public string Lakcim { get; set; } = null!;

    public bool BoldogKutya { get; set; }

    public bool Nem { get; set; }

    public virtual Telepulesek IrszamNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Kutya> Kutyas { get; set; } = new List<Kutya>();
}
