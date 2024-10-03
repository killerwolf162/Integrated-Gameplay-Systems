using UnityEngine;

public class Player : Unit
{
    private InputHandler inputHandler = new InputHandler();

    public override void Start()
    {
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
    }

    public override void Update()
    {
        inputHandler.HandleInput();
    }
}
