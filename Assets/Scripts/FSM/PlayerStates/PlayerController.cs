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
        public PlayerIdle _idleState { get; private set; } = new PlayerIdle();
        public PlayerMove _moveState { get; private set; } = new PlayerMove();


        public Rigidbody2D rb;

        private InputHandler _inputHandler = new InputHandler();

        private ObjectPool<IBullet> _bulletPool = new ObjectPool<IBullet>(new List<IBullet>() {
        new Bullet(0),
        new Bullet(5),
        new Bullet(10)
    });

        public PlayerController(GameObject gameobject)
        {
            this.gameobject = gameobject;
            rb = gameobject.GetComponent<Rigidbody2D>();
            Start();
        }

        public GameObject gameobject { get; }

        public virtual void Start()
        {
            GameHandler.instance.Subscribe(this);

            //initialize statemachine and entry state
            stateMachine = new StateMachine<PlayerController>(this);
            stateMachine.SetState(_idleState);

            //initialize input bindings
            _inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new FireDecorateBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new IceDecorateBulletCommand(_bulletPool));
            _inputHandler.BindKeyToCommand(KeyCode.E, KeypressType.Down, new ShootBulletCommand(_bulletPool));
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
