using PlayerNS;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private GameObject _playerPrefab;
    
    public ISceneObject _player;

    private List<ISceneObject> _updateables = new List<ISceneObject>();
    

    private void Start()
    {
        instance = this;
        _player = new PlayerController(Instantiate(_playerPrefab));
    }

    private void Update()
    {
        for (int i = 0; i < _updateables.Count; i++)
        {
            _updateables[i].Update();
        }
    }

    public void Subscribe(ISceneObject updateable)
    {
        if (!_updateables.Contains(updateable))
        {
            _updateables.Add(updateable);
        }
    }

    public void UnSubscribe(ISceneObject updateable)
    {
        if (_updateables.Contains(updateable))
        {
            _updateables.Remove(updateable);
        }
    }

    public void CreateBullet(GameObject bullet)
    {
        Instantiate(bullet);
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}