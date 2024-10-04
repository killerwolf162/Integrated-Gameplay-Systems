using FSM;

namespace Enemy
{
    public class EnemyChase : AState<EnemyBehaviour>
    {

        public override void Start(EnemyBehaviour runner)
        {
            base.Start(runner);
        }

        public override void Update(EnemyBehaviour runner)
        {
            base.Update(runner);

            runner.agent.SetDestination(runner.player.position);

            if (!runner.inChaseRange) onSwitch(runner.idleState);
        }

        public override void Complete(EnemyBehaviour runner)
        {
            base.Complete(runner);
        }

    }
}
