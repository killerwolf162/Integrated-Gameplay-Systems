using Enemy;
using PlayerNS;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _enemySpawners;

    public ISceneObject player;
    public ISceneObject enemy;

    public Camera mainCam;

    private List<IUpdateable> _updateables = new List<IUpdateable>();

    private void Start()
    {
        instance = this;
        player = new PlayerController(Instantiate(_playerPrefab));
        mainCam = FindAnyObjectByType<Camera>();
        SpawnEnemies();
    }

    private void Update()
    {
        for (int i = 0; i < _updateables.Count; i++)
        {
            _updateables[i].Update();
        }
    }

    public void Subscribe(IUpdateable updateable)
    {
        if (!_updateables.Contains(updateable))
        {
            _updateables.Add(updateable);
        }
    }

    public void UnSubscribe(IUpdateable updateable)
    {
        if (_updateables.Contains(updateable))
        {
            _updateables.Remove(updateable);
        }
    }

    public GameObject InstantiateNew(GameObject gameObject)
    {
        return Instantiate(gameObject);
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }

    public void SpawnEnemies()
    {
        foreach (GameObject spawner in _enemySpawners)
        {
            Vector3 pos = spawner.transform.position;
            EnemyBehaviour enemy = new EnemyBehaviour(Instantiate(_enemyPrefab), pos);

        }
    }
}