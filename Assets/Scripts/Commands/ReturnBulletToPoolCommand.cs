using System.Collections.Generic;
using UnityEngine;

public class ReturnBulletToPoolCommand : ICommand
{
    private ObjectPool<IBullet> _bulletPool;

    public ReturnBulletToPoolCommand(ObjectPool<IBullet> bulletPool)
    {
        this._bulletPool = bulletPool;
    }

    public IAbilityActor actor { get; private set; }

    public void Execute()
    {
        ReturnBullet();
    }

    public void ReturnBullet()
    {
        List<IBullet> bulletToDisable = new List<IBullet>();

        foreach (Bullet bullet in _bulletPool._activePool)
        {
            bulletToDisable.Add(bullet);
        }

        foreach (Bullet bullet in bulletToDisable)
        {
            _bulletPool.ReturnItemToPool(bullet);
        }     
    }
}
