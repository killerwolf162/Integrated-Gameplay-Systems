using UnityEngine;

public class FireDecorateBulletCommand : ICommand
{

    private ObjectPool<Bullet> _bulletPool;
    private int _fireDamage = 5;

    public FireDecorateBulletCommand(ObjectPool<Bullet> bulletPool)
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
        _bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Fire, _fireDamage, Color.red)); // replace fireDamage with actor.fireDamage(stored in player(?)) so its easier to change values later.
    }
}
