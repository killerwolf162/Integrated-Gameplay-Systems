using PlayerNS;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;


    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    public ISceneObject _player;

    private List<ISceneObject> _updateables = new List<ISceneObject>();
    private GameObject _bullet;

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

    public GameObject CreateBullet()
    {
        _bullet = Instantiate(_bulletPrefab);
        return _bullet;
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}