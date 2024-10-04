using FSM;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : AState<EnemyBehaviour>
    {
        private float _attackTimer = 3f;
        private float _currentTime = 3f;
        private bool _hasAttacked = true;

        public override void Start(EnemyBehaviour runner)
        {
            base.Start(runner);
            runner.agent.SetDestination(runner.gameobject.transform.position);
            _currentTime = _attackTimer / 2;
        }

        public override void Update(EnemyBehaviour runner)
        {
            base.Update(runner);
            if (!_hasAttacked)
            {
                //Attack Logic
                /*IDamagable iDamagable = actor.player.gameObject.GetComponent<IDamagable>();
                if (iDamagable == null) return;

                iDamagable.Damage(actor.damage);*/

                _hasAttacked = true;
            }

            //attack Delay timer
            if (_currentTime > 0f)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0f) { ResetAttack(); }
            }

            if (!runner.inAttackRange) onSwitch(runner.idleState);
        }

        public override void Complete(EnemyBehaviour runner)
        {
            base.Complete(runner);
        }

        private void ResetAttack()
        {
            _hasAttacked = false;
            _currentTime = _attackTimer;
        }
    }
}
