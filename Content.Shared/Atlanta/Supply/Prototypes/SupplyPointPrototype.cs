using Content.Shared.Random;
using Robust.Shared.Prototypes;

namespace Content.Shared.Atlanta.Supply.Prototypes;

/// <summary>
/// Used to define creation SupplyContent chance.
/// </summary>
[Prototype("supplyPoint")]
public sealed partial class SupplyPointPrototype : IWeightedRandomPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; } = default!;

    /// <summary>
    /// Contains chance of spawn SupplyContent
    /// </summary>
    [DataField]
    public Dictionary<string, float> Weights { get; } = [];
}
