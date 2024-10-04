using FSM;
using UnityEngine;

namespace PlayerNS
{
    public class PlayerIdle : AState<PlayerController>
    {
        public override void Start(PlayerController runner)
        {
            Debug.Log("Enter Idle State");
            base.Start(runner);
        }

        public override void Update(PlayerController runner)
        {
            base.Update(runner);
            if(runner.MoveDirection().magnitude != null)
            {
                onSwitch(runner._moveState);
            }
        }

        public override void Complete(PlayerController runner)
        {
            base.Complete(runner);
        }
    }
}
