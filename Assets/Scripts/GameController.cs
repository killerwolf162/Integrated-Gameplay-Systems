public class GameController : IUpdateable
{
    MonoBehaviourHandler monoBehaviourHandler;

    public GameController(MonoBehaviourHandler monobehaviour)
    {
        monoBehaviourHandler = monobehaviour;
        monobehaviour.Subscribe(this);
        Start();
    }

    public void Start()
    {

    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Cleanup()
    {
        monoBehaviourHandler.UnSubscribe(this);
    }
}