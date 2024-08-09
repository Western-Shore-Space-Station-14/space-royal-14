using Content.Shared.Atlanta.Mist.Components;
using Content.Shared.Atlanta.Mist.Systems;
using Content.Shared.Damage;
using Content.Shared.Damage.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Server.Atlanta.Mist.Systems;

/// <summary>
/// This handles...
/// </summary>
public sealed class MistPlayerSystem : SharedMistPlayerSystem
{
    [Dependency] private readonly DamageableSystem _damageable = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    protected override void ProcessDistance(EntityUid target, MistPlayerComponent playerMist, float frameTime, float distance)
    {
        base.ProcessDistance(target, playerMist, frameTime, distance);

        if (distance >= playerMist.DeathDistance)
        {
            _damageable.TryChangeDamage(target,
                new DamageSpecifier(_prototypeManager.Index<DamageTypePrototype>("Asphyxiation"), 10 * frameTime));
        }
    }
}
