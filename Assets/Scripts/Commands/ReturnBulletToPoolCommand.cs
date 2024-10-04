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
        List<IBullet> bulletList = new List<IBullet>();

        foreach (Bullet bullet in _bulletPool._activePool)
        {
            if(bullet._timer > bullet._timeOutTime)
            {
                bulletList.Add(bullet);
            }
        }

        foreach (Bullet bullet in bulletList)
        {
            _bulletPool.ReturnItemToPool(bullet);
        }     
    }
}
