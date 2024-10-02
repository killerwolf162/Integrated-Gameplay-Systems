using UnityEngine;

public class Player : Unit
{
    private InputHandler inputHandler = new InputHandler();

    private void Start()
    {
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
    }

    public void Update()
    {
        inputHandler.HandleInput();
    }
}
