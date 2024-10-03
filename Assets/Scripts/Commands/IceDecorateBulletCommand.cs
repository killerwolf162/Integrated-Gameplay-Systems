public class IceDecorateBulletCommand : ICommand
{

    private ObjectPool<IBullet> _bulletPool;

    private int _iceDamage = 5;

    public IceDecorateBulletCommand(ObjectPool<IBullet> bulletPool)
    {
        this._bulletPool = bulletPool;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        DecorateBullet();
    }

    private void DecorateBullet()
    {
        _bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Ice, _iceDamage)); // replace iceDamage with actor.iceDamage(stored in player(?)) so its easier to change values later.
    }
}
