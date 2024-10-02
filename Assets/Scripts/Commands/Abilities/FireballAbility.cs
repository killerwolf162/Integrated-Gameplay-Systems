using UnityEngine;

public class FireballAbility : AbilityBase, ICommand
{
    public IAbilityActor actor { get; private set; }

    public FireballAbility(IAbilityActor actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Debug.Log($"{actor.GameObject().name} casted a fireball");
    }
}
