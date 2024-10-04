using FSM;
using UnityEngine;

namespace PlayerNS
{
    public class PlayerMove : AState<PlayerController>
    {
        private float _moveSpeed = 20f;

        public override void Start(PlayerController runner)
        {
            base.Start(runner);
        }

        public override void Update(PlayerController runner)
        {
            Vector3 dir = new Vector3(runner.MoveDirection().x, runner.MoveDirection().y ,0);

            runner.rb.MovePosition(runner.gameobject.transform.position + dir * Time.deltaTime * _moveSpeed);

            if (runner.MoveDirection().magnitude < 0.1)
            {
                onSwitch(runner.idleState);
            }
        }

        public override void Complete(PlayerController runner)
        {
            base.Complete(runner);
        }
    }
}