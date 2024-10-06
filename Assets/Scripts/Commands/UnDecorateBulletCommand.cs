using UnityEngine;

public class UnDecorateBulletCommand : ICommand
{
    private ObjectPool<Bullet> _bulletPool;

    private int _damage;

    public UnDecorateBulletCommand(ObjectPool<Bullet> bulletPool, int damage)
    {
        this._bulletPool = bulletPool;
        _damage = damage;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        DecorateBullet();
    }

    private void DecorateBullet()
    {
        _bulletPool.RequestObject()?.Decorate(new UnDecorator(ElementalBulletTypes.Normal, _damage, Color.black)); // replace iceDamage with actor.iceDamage(stored in player(?)) so its easier to change values later.
    }
}
