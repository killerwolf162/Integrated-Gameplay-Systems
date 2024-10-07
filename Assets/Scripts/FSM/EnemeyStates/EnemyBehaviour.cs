using FSM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyBehaviour : IStateRunner, ISceneObject
    {
        [Header("General")]
        public Rigidbody2D rb;
        public Collider2D col;
        public GameObject gameobject { get; private set; }

        [Header("StateMachine")]
        public StateMachine<EnemyBehaviour> stateMachine;
        public ScratchPad sharedData => new ScratchPad();
        public EnemyIdle idleState { get; private set; } = new EnemyIdle();
        public EnemyPatrol patrolState { get; private set; } = new EnemyPatrol();
        public EnemyChase chaseState { get; private set; } = new EnemyChase();
        public EnemyAttack attackState { get; private set; } = new EnemyAttack();

        [Header("Checks")]
        public LayerMask playerMask = 3; //player mask
        public float chaseRange = 10f;
        public float attackRange = 3f;
        public bool inChaseRange;
        public bool inAttackRange;

        [Header("AI")]
        public Transform player;


        //constructor
        public EnemyBehaviour(GameObject gameobject, Vector2 position)
        {
            gameobject.transform.position = position;
            this.gameobject = gameobject;
            rb = gameobject.GetComponent<Rigidbody2D>();
            col = gameobject.GetComponent<Collider2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Start();
        }

        public virtual void Start()
        {
            GameHandler.instance.Subscribe(this);

            //initialize statemachine and entry state
            stateMachine = new StateMachine<EnemyBehaviour>(this);
            stateMachine.SetState(idleState);
        }

        public virtual void Update()
        {
            if (gameobject == null)
            {
                GameHandler.instance.UnSubscribe(this);
            }

            //update loop statemachine
            stateMachine?.Update();
            CheckPlayerInRange();
            if(col != null)
            {
                OnCollisionEnter2D(col);
            }

        }

        //check if the enemy gives chase or attacks
        public void CheckPlayerInRange()
        {
            stateMachine.SetState(chaseState); // let AI always be in chase state, no time left to actually make the rest work well - Tom
/*
            Collider2D detectedObject = Physics2D.OverlapCircle(gameobject.transform.position, chaseRange, playerMask); 

            if (detectedObject != null)
            {
                float distance = Vector3.Distance(gameobject.transform.position, player.position);

                //if (distance < attackRange) stateMachine.SetState(attackState); 
                if (distance < chaseRange) stateMachine.SetState(chaseState);
            }

           inChaseRange = Physics.CheckSphere(gameobject.transform.position, chaseRange, playerMask);
            inAttackRange = Physics.CheckSphere(gameobject.transform.position, attackRange, playerMask);

            if (inChaseRange && inAttackRange) {
                stateMachine.SetState(attackState);
            }
            else if(inChaseRange && !inAttackRange)
            {
                stateMachine.SetState(chaseState);
            }*/
        }

        private void OnCollisionEnter2D(Collider2D collider)
        {
            List<Collider2D> overlappingColliders = new List<Collider2D>();
            ContactFilter2D enemyFilter = new ContactFilter2D();

            collider.OverlapCollider(enemyFilter, overlappingColliders);

            foreach (Collider2D otherCollider in overlappingColliders)
            {
                
                if (otherCollider.tag == "Fireball")
                {
                    GameHandler.instance.UnSubscribe(this);
                    GameHandler.instance.DestroyObject(gameobject);                    
                }
            }
        }

    }
}
