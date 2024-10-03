public class IceDecorateBulletCommand : ICommand
{

    private ObjectPool<IBullet> bulletPool;

    private int iceDamage = 5;

    public IceDecorateBulletCommand(ObjectPool<IBullet> bulletPool)
    {
        this.bulletPool = bulletPool;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        DecorateBullet();
    }

    private void DecorateBullet()
    {
        bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Ice, iceDamage)); // replace iceDamage with actor.iceDamage(stored in player(?)) so its easier to change values later.
    }
}
