using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private InputHandler inputHandler = new InputHandler();

    private ObjectPool<IBullet> bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
        new Bullet(0),
        new Bullet(5),
        new Bullet(10)
    });

    private void Start()
    {
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
        inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new FireDecorateBulletCommand(bulletPool));
        inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new IceDecorateBulletCommand(bulletPool));
        inputHandler.BindKeyToCommand(KeyCode.E, KeypressType.Down, new ShootBulletCommand(bulletPool));
    }

    public void Update()
    {
        inputHandler.HandleInput();
    }
}
