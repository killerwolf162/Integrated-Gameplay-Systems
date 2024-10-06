public class FireballAbility : AbilityBase, ICommand
{
    public IAbilityActor actor { get; private set; }

    public FireballAbility(IAbilityActor actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Fireball fireball = new Fireball(actor.GameObject().transform.position, actor.GetAimDirection());
    }
}
