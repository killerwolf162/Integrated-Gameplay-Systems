using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyBehaviour : IStateRunner, ISceneObject
    {
        [Header("General")]
        public Rigidbody2D rb;
        public GameObject gameobject { get; private set; }
        
        [Header("StateMachine")]
        public StateMachine<EnemyBehaviour> stateMachine;
        public ScratchPad sharedData => new ScratchPad();
        public EnemyIdle idleState { get; private set; } = new EnemyIdle();
        public EnemyPatrol patrolState { get; private set; } = new EnemyPatrol();
        public EnemyChase chaseState { get; private set; } = new EnemyChase();
        public EnemyAttack attackState { get; private set; } = new EnemyAttack();

        [Header("Checks")]
        public LayerMask playerMask;
        public float chaseRange;
        public float attackRange;
        public bool inChaseRange;
        public bool inAttackRange;

        [Header("AI")]
        public NavMeshAgent agent;
        public Transform player;


        //constructor
        public EnemyBehaviour(GameObject gameobject)
        {
            this.gameobject = gameobject;
            rb = gameobject.GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Start();
        }

        public virtual void Start()
        {
            GameHandler.instance.Subscribe(this);

            //initialize statemachine and entry state
            stateMachine = new StateMachine<EnemyBehaviour>(this);
            stateMachine.SetState(null); //# give state on start
        }

        public virtual void Update()
        {
            //update loop statemachine
            stateMachine?.Update();
            CheckPlayerInRange();
        }

        //check if the enemy gives chase or attacks
        public void CheckPlayerInRange()
        {
            inChaseRange = Physics.CheckSphere(gameobject.transform.position, chaseRange, playerMask);
            inAttackRange = Physics.CheckSphere(gameobject.transform.position, attackRange, playerMask);

            if (inChaseRange && inAttackRange) {
                stateMachine.SetState(attackState);
            }
            else if(inChaseRange && !inAttackRange)
            {
                stateMachine.SetState(chaseState);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gameobject.transform.position, chaseRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(gameobject.transform.position, attackRange);
        }

    }
}
