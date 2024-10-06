using UnityEngine;

public class FireDecorateBulletCommand : ICommand
{

    private ObjectPool<Bullet> _bulletPool;
    private int _fireDamage;

    public FireDecorateBulletCommand(ObjectPool<Bullet> bulletPool, int damage)
    {
        this._bulletPool = bulletPool;
        _fireDamage = damage;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        DecorateBullet();
    }

    private void DecorateBullet()
    {
        _bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Fire, _fireDamage, Color.red)); // replace fireDamage with actor.fireDamage(stored in player(?)) so its easier to change values later.
    }
}
