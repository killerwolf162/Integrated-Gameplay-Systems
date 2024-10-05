using FSM;
using UnityEngine;
using System.Collections.Generic;

namespace PlayerNS
{
    public class PlayerController : IStateRunner, ISceneObject, IAbilityActor
    {
        [Header("StateMachine")]
        public StateMachine<PlayerController> stateMachine;
        public ScratchPad sharedData => new ScratchPad();
        public PlayerIdle idleState { get; private set; } = new PlayerIdle();
        public PlayerMove moveState { get; private set; } = new PlayerMove();

        public Rigidbody2D rb;

        private ObjectPool<IBullet> _bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black),
            new Bullet(GameHandler.instance.bulletPrefab, 5, Color.black)
    });

        private InputHandler _inputHandler = new InputHandler();
        public GameObject gameobject { get; private set; }

        public PlayerController(GameObject gameobject)
        {
            this.gameobject = gameobject;
            rb = gameobject.GetComponent<Rigidbody2D>();
            Start();
        }


        public virtual void Start()
        {
            GameHandler.instance.Subscribe(this);

            //initialize statemachine and entry state
            stateMachine = new StateMachine<PlayerController>(this);
            stateMachine.SetState(idleState);

            //initialize bullet pool at start
            foreach (Bullet bullet in _bulletPool._inactivePool)
            {
                Debug.Log("set death event");
                bullet.OnDie += OnBulletDie;
                bullet.Start();
            }

            //initialize input bindings
            _inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new FireDecorateBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha3, KeypressType.Down, new IceDecorateBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new UnDecorateBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.Mouse0, KeypressType.Down, new ShootBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.R, KeypressType.Down, new ReturnBulletToPoolCommand(_bulletPool));
        }

        public virtual void Update()
        {
            _inputHandler.HandleInput();

            Debug.Log(_bulletPool._activePool.Count);
            Debug.Log(_bulletPool._inactivePool.Count);


            //update loop statemachine
            stateMachine?.Update();
        }

        public void OnBulletDie(Bullet bullet)
        {
            _bulletPool.ReturnItemToPool(bullet);
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
            Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveDir;
        }
    }
}
