public class ShootBulletCommand : ICommand
{

    private ObjectPool<IBullet> bulletPool;

    public ShootBulletCommand(ObjectPool<IBullet> bulletPool)
    {
        this.bulletPool = bulletPool;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        ShootBullet();   
    }

    private void ShootBullet()
    {
        bulletPool.ActivateItem(bulletPool.RequestObject())?.ShootBullet();  
    }
}
