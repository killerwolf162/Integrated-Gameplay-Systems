using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameEntity> gameEntities = new List<GameEntity>();

    public Unit unit;

    void Start()
    {
        for (int i = 0; i < gameEntities.Count; i++)
        {
            gameEntities[i].unit.Start();
        }
    }

    void Update()
    {
        for (int i = 0; i < gameEntities.Count; i++)
        {
            gameEntities[i].unit.Update();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < gameEntities.Count; i++)
        {
            gameEntities[i].unit.FixedUpdate();
        }
    }
}

[Serializable]
public class GameEntity
{
    public GameObject gameobject;
    public Unit unit;
}
