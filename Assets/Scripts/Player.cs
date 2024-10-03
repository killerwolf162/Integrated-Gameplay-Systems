using UnityEngine;

public class Player : IAbilityActor
{
    private InputHandler inputHandler = new InputHandler();

    public void Start()
    {
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
    }

    public void Update()
    {
        inputHandler.HandleInput();
    }

    public GameObject GameObject()
    {
        throw new System.NotImplementedException();
    }

    public Vector2 GetAimDirection()
    {
        throw new System.NotImplementedException();
    }

    public Vector2 MoveDirection()
    {
        throw new System.NotImplementedException();
    }
}
