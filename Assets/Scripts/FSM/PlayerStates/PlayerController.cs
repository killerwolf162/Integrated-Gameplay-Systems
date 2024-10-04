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

        [Header("General")]
        public Rigidbody2D rb;
        public GameObject gameobject { get; private set; }

        //can probably be done better by instantiating them with a for loop
        private ObjectPool<IBullet> _bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
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

        private InputHandler _inputHandler = new InputHandler();

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

            //initialize input bindings
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

            //update loop statemachine
            stateMachine?.Update();
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
