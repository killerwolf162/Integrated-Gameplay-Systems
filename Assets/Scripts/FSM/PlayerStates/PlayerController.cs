using FSM;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace PlayerNS
{
    public class PlayerController : IStateRunner, ISceneObject, IAbilityActor, IShooter
    {
        [Header("StateMachine")]
        public StateMachine<PlayerController> stateMachine;
        public ScratchPad sharedData => new ScratchPad();
        public PlayerIdle idleState { get; private set; } = new PlayerIdle();
        public PlayerMove moveState { get; private set; } = new PlayerMove();

        public GameObject gameobject { get; private set; }

        public Rigidbody2D rb;
        public Collider2D col;

        private ObjectPool<Bullet> _bulletPool = new ObjectPool<Bullet>(new List<Bullet>(){});

        private InputHandler _inputHandler = new InputHandler();

        private Camera _mainCam;
        private Vector3 _mousePos;

        private float _damageTimeOut;

        private int _spellCount = 15;
        private int _health = 10;

        private int _fireDamage;
        private int _iceDamage;
        private int _baseDamage;


        public PlayerController(GameObject gameobject)
        {
            this.gameobject = gameobject;
            rb = gameobject.GetComponent<Rigidbody2D>();
            col = gameobject.GetComponent<Collider2D>();
            Start();
        }

        public virtual void Start()
        {
            GameObject bulletObject = Resources.Load("Bullet", typeof(GameObject)) as GameObject;

            for (int i = 0; i < _spellCount; i++) // creates bullets/spels and puts them into objectpool
            {
                var bullet = GameHandler.instance.InstantiateNew(bulletObject);
                _bulletPool._inactivePool.Add(CreateBullet(bullet));
            }

            GameHandler.instance.Subscribe(this);
            _mainCam = GameHandler.instance.mainCam;

            //initialize statemachine and entry state
            stateMachine = new StateMachine<PlayerController>(this);
            stateMachine.SetState(idleState);

            //initialize bullet pool at start
            foreach (Bullet bullet in _bulletPool._inactivePool)
            {
                bullet.OnDie += OnBulletDie;
                bullet.Start();
            }

            //initialize input bindings
            //_inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
            _inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new FireballAbility(this));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha2, KeypressType.Down, new FireDecorateBulletCommand(_bulletPool, _fireDamage));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha3, KeypressType.Down, new IceDecorateBulletCommand(_bulletPool, _iceDamage));
            _inputHandler.BindKeyToCommand(KeyCode.Alpha1, KeypressType.Down, new UnDecorateBulletCommand(_bulletPool, _baseDamage));
            _inputHandler.BindKeyToCommand(KeyCode.Mouse0, KeypressType.Down, new ShootBulletCommand(_bulletPool));
        }

        public virtual void Update()
        {
            _inputHandler.HandleInput();

            _damageTimeOut -= Time.deltaTime;

            //update loop statemachine
            stateMachine?.Update();

            SetCameraPosition();
            OnCollisionEnter2D(col);
        }

        public void OnBulletDie(Bullet _bullet)
        {         
            _bulletPool.ReturnItemToPool(_bullet);
        }

        public GameObject GameObject()
        {
            return gameobject;
        }

        public Bullet CreateBullet(GameObject bulletObject)
        {
            Bullet bullet = new Bullet(bulletObject, this, _baseDamage, Color.black);
            return bullet;
        }

        public Vector2 GetAimDirection()
        {
            _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            var directionToGive = _mousePos - gameobject.transform.position;

            return directionToGive;
        }

        public Quaternion GetBulletRotation()
        {
            _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = _mousePos - gameobject.transform.position;
            float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            return Quaternion.Euler(0, 0, zRotation - 90);
        }

        public Vector2 MoveDirection()
        {
            Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveDir;
        }

        public void SetCameraPosition()
        {
            GameHandler.instance.mainCam.transform.position = gameobject.transform.position + new Vector3(0, 0, -10);
        }
        private void OnCollisionEnter2D(Collider2D collider)
        {
            List<Collider2D> overlappingColliders = new List<Collider2D>();
            ContactFilter2D enemyFilter = new ContactFilter2D();

            collider.OverlapCollider(enemyFilter, overlappingColliders);

            foreach (var otherCollider in overlappingColliders)
            {             
                if (otherCollider.tag == "Enemy")
                {
                    if (_damageTimeOut < 0)
                    {
                        _health -= 1;
                        Debug.Log(_health);
                        _damageTimeOut = 1;
                    }
                }
            }
        }
    }
}
