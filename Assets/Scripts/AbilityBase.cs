using UnityEngine;

public abstract class AbilityBase
{
    protected float cooldownTime = 0;
}


public class DashAbility : AbilityBase, ICommand
{
    public AbilityActor actor { get; private set; }

    public DashAbility(AbilityActor actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Debug.Log($"{actor.GameObject().name} is dashing");
    }
}

public class FireballAbility : AbilityBase, ICommand
{
    public AbilityActor actor { get; private set; }

    public FireballAbility(AbilityActor actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Debug.Log($"{actor.GameObject().name} casted a fireball");
    }
}
