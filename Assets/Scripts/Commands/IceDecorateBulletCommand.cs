using UnityEngine;

public class IceDecorateBulletCommand : ICommand
{

    private ObjectPool<Bullet> _bulletPool;

    private int _iceDamage;

    public IceDecorateBulletCommand(ObjectPool<Bullet> bulletPool, int damage)
    {
        this._bulletPool = bulletPool;
        _iceDamage = damage;
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
