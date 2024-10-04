using PlayerNS;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField]
    private GameObject playerPrefab;

    private List<ISceneObject> updateables = new List<ISceneObject>();

    private ISceneObject player;

    private void Start()
    {
        instance = this;
        //player = new Player(Instantiate(playerPrefab));
        player = new PlayerController(Instantiate(playerPrefab)); //for testing purpose
    }

    private void Update()
    {
        foreach (var updateable in updateables)
        {
            updateable.Update();
        }
    }

    public void Subscribe(ISceneObject updateable)
    {
        if (!updateables.Contains(updateable))
        {
            updateables.Add(updateable);
        }
    }

    public void UnSubscribe(ISceneObject updateable)
    {
        if (updateables.Contains(updateable))
        {
            updateables.Remove(updateable);
        }
    }
}
