using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : ISceneObject
{
    public GameObject thisEnemy;
    public GameObject gameobject { get; private set; }


    //constructor
    private EnemySpawner(GameObject gameobject)
    {
        this.gameobject = gameobject;
        Start();
    }


    public virtual void Start()
    {
        GameHandler.instance.Subscribe(this);
    }

    public virtual void Update()
    {
        //every so many seconds spawn an enemy

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Instantiate the enemy from a prefab
        GameObject newEnemy = GameHandler.Instantiate(thisEnemy, Vector3.zero, Quaternion.identity);

        // Optionally, get the EnemyBehaviour component and interact with it
        EnemyBehaviour enemyBehaviour = newEnemy.GetComponent<EnemyBehaviour>();

        if (enemyBehaviour != null)
        {
            // Do something with the enemy's behaviour if needed
        }
    }
} 
