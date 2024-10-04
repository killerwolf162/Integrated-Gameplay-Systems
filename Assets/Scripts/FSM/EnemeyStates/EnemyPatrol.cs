using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyPatrol : AState<EnemyBehaviour>
    {
        private Vector3 _walkPoint;
        private float _walkPointRange = 10f;
        private bool _walkPointSet;

        public override void Start(EnemyBehaviour runner)
        {
            base.Start(runner);
        }

        public override void Update(EnemyBehaviour runner)
        {
            base.Update(runner);

            if (!_walkPointSet) GetNewWalkPoint(runner);

            if (_walkPointSet)
            {
                runner.agent.SetDestination(_walkPoint);
            }

            Vector3 disToWalkPoint = runner.gameobject.transform.position - _walkPoint;

            if (disToWalkPoint.magnitude < 1)
            {
                onSwitch(runner.idleState);
            }

        }

        public override void Complete(EnemyBehaviour runner)
        {
            _walkPointSet = false;
            base.Complete(runner);
        }

        private void GetNewWalkPoint(EnemyBehaviour runner)
        {
            float randomY = Random.Range(-_walkPointRange, _walkPointRange);
            float randomX = Random.Range(-_walkPointRange, _walkPointRange);

            Vector3 pos = runner.gameobject.transform.position;
            _walkPoint = new Vector3(pos.x + randomX, pos.y + randomY, 0);

            //checks if the walkpoint is on the NavMesh 
            if (NavMesh.SamplePosition(_walkPoint, out _, 1.0f, NavMesh.AllAreas)) _walkPointSet = true;
        }

    }
}
