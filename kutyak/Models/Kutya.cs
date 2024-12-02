using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace kutyak.Models;

public partial class Kutya
{
    public int? Id { get; set; }

    public int? GazdaId { get; set; }

    public int? FajtaId { get; set; }

    public int? Eletkor { get; set; }

    public string? ChipNumber { get; set; } = null!;

    public string? Nev { get; set; } = null!;

    public byte[]? IndexKep { get; set; } = null!;

    public byte[]? Kep { get; set; } = null!;

    [JsonIgnore]
    public virtual Fajtum Fajta { get; set; } = null!;

    [JsonIgnore]
    public virtual Gazdum Gazda { get; set; } = null!;
}
