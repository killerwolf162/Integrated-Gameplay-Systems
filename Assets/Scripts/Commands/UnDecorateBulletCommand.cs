﻿using UnityEngine;

public class UnDecorateBulletCommand : ICommand
{
    private ObjectPool<IBullet> _bulletPool;

    private int _damage = 5;

    public UnDecorateBulletCommand(ObjectPool<IBullet> bulletPool)
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
        _bulletPool.RequestObject()?.Decorate(new UnDecorator(ElementalBulletTypes.Normal, _damage, Color.black)); // replace iceDamage with actor.iceDamage(stored in player(?)) so its easier to change values later.
    }
}
