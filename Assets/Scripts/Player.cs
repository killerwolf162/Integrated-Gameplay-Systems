using System.Collections.Generic;
using UnityEngine;

public class Player : IAbilityActor, ISceneObject
{
    private InputHandler inputHandler = new InputHandler();

    private ObjectPool<IBullet> bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
        new Bullet(0),
        new Bullet(5),
        new Bullet(10)
    });

    public GameObject gameobject { get; private set; }

    public Player(GameObject gameobject)
    {
        this.gameobject = gameobject;
        Start();
    }

    public virtual void Start()
    {
        GameHandler.instance.Subscribe(this);
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
        inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new FireDecorateBulletCommand(bulletPool));
        inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new IceDecorateBulletCommand(bulletPool));
        inputHandler.BindKeyToCommand(KeyCode.E, KeypressType.Down, new ShootBulletCommand(bulletPool));
    }

    public virtual void Update()
    {
        inputHandler.HandleInput();
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
