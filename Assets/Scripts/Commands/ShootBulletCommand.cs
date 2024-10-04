public class ShootBulletCommand : ICommand
{

    private ObjectPool<IBullet> _bulletPool;

    public ShootBulletCommand(ObjectPool<IBullet> bulletPool)
    {
        this._bulletPool = bulletPool;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
       ShootBullet();   
    }

    private void ShootBullet()
    {
        _bulletPool.ActivateItem(_bulletPool.RequestObject())?.OnEnableObject();  
    }
}
