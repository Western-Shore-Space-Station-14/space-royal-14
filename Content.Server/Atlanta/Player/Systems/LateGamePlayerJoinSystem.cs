using Content.Server.Atlanta.GameTicking.Rules;
using Content.Server.Atlanta.Player.Events;

namespace Content.Server.Atlanta.Player.Systems;

/// <summary>
/// This is used for late game connection if it needs to wait some logic before spawn.
/// Used in <seealso cref="MistGameRuleSystem"/>
/// </summary>
public sealed class LateGamePlayerJoinSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _entityManager = default!;
    public override void Initialize()
    {
        SubscribeLocalEvent<LateGamePlayerJoinComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(Entity<LateGamePlayerJoinComponent> ent, ref ComponentStartup args)
    {
        var proto = MetaData(ent.Owner).EntityPrototype;

        if (proto == null)
            return;

        var ev = new ExtendedLateJoinPointRegisterEvent(ent.Owner, proto);
        RaiseLocalEvent(ev);
    }
}
