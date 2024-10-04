using FSM;
using UnityEngine;

namespace PlayerNS
{
    public class PlayerMove : AState<PlayerController>
    {
        private float _moveSpeed = 20f;

        public override void Start(PlayerController runner)
        {
            Debug.Log("Enter Move State");
            base.Start(runner);
        }

        public override void Update(PlayerController runner)
        {
            //Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //runner.rb.MovePosition(runner.transform.position + moveInput * Time.deltaTime * _moveSpeed);

            //if (moveInput != Vector3.zero)
            //{
            //    runner.rb.MovePosition(runner.transform.position + moveInput * Time.deltaTime * _moveSpeed);
            //}

            if (runner.MoveDirection().magnitude == null)
            {
                onSwitch(runner._idleState);
            }
        }

        public override void Complete(PlayerController runner)
        {
            Debug.Log("Switching to idleState");
            base.Complete(runner);
        }
    }
}