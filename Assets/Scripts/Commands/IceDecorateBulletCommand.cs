using UnityEngine;

public class IceDecorateBulletCommand : ICommand
{

    private ObjectPool<Bullet> _bulletPool;

    private int _iceDamage = 5;

    public IceDecorateBulletCommand(ObjectPool<Bullet> bulletPool)
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
        _bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Ice, _iceDamage, Color.blue)); // replace iceDamage with actor.iceDamage(stored in player(?)) so its easier to change values later.
    }
}
