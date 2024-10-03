using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourHandler : MonoBehaviour
{
    [SerializeField]
    private List<IUpdateable> updateables = new List<IUpdateable>();

    GameController gameController;

    private void Start()
    {
        gameController = new GameController(this);
    }

    private void Update()
    {
        foreach (var updateable in updateables)
        {
            updateable.Update();
        }
    }

    public void Subscribe(IUpdateable updateable)
    {
        if (!updateables.Contains(updateable))
        {
            updateables.Add(updateable);
        }
    }

    public void UnSubscribe(IUpdateable updateable)
    {
        if (updateables.Contains(updateable))
        {
            updateables.Remove(updateable);
        }
    }

    private void OnDestroy()
    {
        if (gameController != null)
        {
            gameController.Cleanup();
        }
    }
}
