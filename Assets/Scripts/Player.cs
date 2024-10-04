using System.Collections.Generic;
using UnityEngine;

public class Player : IAbilityActor, ISceneObject
{
    public ObjectPool<IBullet> _bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
        new Bullet(5, Color.black),
    });
    public GameObject gameobject { get; private set; }

    private InputHandler _inputHandler = new InputHandler();

    public Player(GameObject gameobject)
    {
        this.gameobject = gameobject;
        Start();
    }

    public virtual void Start()
    {
        GameHandler.instance.Subscribe(this);

        _inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
        _inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new FireDecorateBulletCommand(_bulletPool));
        _inputHandler.BindKeyToCommand(KeyCode.Alpha3, KeypressType.Down, new IceDecorateBulletCommand(_bulletPool));
        _inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new UnDecorateBulletCommand(_bulletPool));
        _inputHandler.BindKeyToCommand(KeyCode.E, KeypressType.Down, new ShootBulletCommand(_bulletPool));
        _inputHandler.BindKeyToCommand(KeyCode.R, KeypressType.Down, new ReturnBulletToPoolCommand(_bulletPool));

    }

    public virtual void Update()
    {
        _inputHandler.HandleInput();
    }

    public GameObject GameObject()
    {
        return gameobject;
    }

    public Vector2 GetAimDirection()
    {
        return new Vector2(0f, 0f);
    }

    public Vector2 MoveDirection()
    {
        return new Vector2(0f, 0f);
    }
}
