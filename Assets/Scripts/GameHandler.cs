using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;


    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    private List<ISceneObject> _updateables = new List<ISceneObject>();

    private ISceneObject _player;
    private GameObject _bullet;

    

    private void Start()
    {
        instance = this;
        _player = new Player(Instantiate(_playerPrefab));
    }

    private void Update()
    {
        foreach (var updateable in _updateables)
        {
            updateable.Update();
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
}
