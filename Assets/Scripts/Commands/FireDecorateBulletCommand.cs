using UnityEngine;

public class FireDecorateBulletCommand : ICommand
{

    private ObjectPool<IBullet> bulletPool;

    private int fireDamage = 5;

    public FireDecorateBulletCommand(ObjectPool<IBullet> bulletPool)
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
        bulletPool.RequestObject()?.Decorate(new ElementDecorator(ElementalBulletTypes.Fire, fireDamage)); // replace fireDamage with actor.fireDamage(stored in player(?)) so its easier to change values later.
    }
}
