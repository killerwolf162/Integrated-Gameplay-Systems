using UnityEngine;

public class DashAbility : AbilityBase, ICommand
{
    public IAbilityActor actor { get; private set; }

    public DashAbility(IAbilityActor actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Debug.Log($"{actor.GameObject().name} is dashing");
        Transform actorTransform = actor.GameObject().transform;
        actorTransform.position += (Vector3)actor.MoveDirection();
    }
}
