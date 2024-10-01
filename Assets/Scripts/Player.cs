using UnityEngine;

public class Player : MonoBehaviour, AbilityActor
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

    public GameObject GameObject()
    {
        return gameObject;
    }

    public Vector2 GetAimDirection()
    {
        return new Vector2(1f, 0f);
    }
}
