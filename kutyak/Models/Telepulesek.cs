using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace kutyak.Models;

public partial class Telepulesek
{
    public int Irszam { get; set; }

    public string Telepules { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<Gazdum> Gazda { get; set; } = new List<Gazdum>();
}
