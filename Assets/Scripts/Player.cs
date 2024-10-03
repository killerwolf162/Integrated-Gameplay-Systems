using UnityEngine;

public class Player : IAbilityActor, ISceneObject
{
    private InputHandler inputHandler = new InputHandler();

    public GameObject gameobject { get; private set; }

    public Player(GameObject gameobject)
    {
        this.gameobject = gameobject;
        Start();
    }

    public virtual void Start()
    {
        GameHandler.instance.Subscribe(this);
        inputHandler.BindKeyToCommand(KeyCode.Space, KeypressType.Down, new DashAbility(this));
    }

    public virtual void Update()
    {
        inputHandler.HandleInput();
    }

    public GameObject GameObject()
    {
        return gameobject;
    }

    public Vector2 GetAimDirection()
    {
        return new Vector2(0f, 0f);
    }

    public Vector2 MoveDirection()
    {
        return new Vector2(0f, 0f);
    }
}
