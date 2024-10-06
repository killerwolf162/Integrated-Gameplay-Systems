using Enemy;
using PlayerNS;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private Color _baseBulletColor;

    public ISceneObject _player;

    private List<ISceneObject> _updateables = new List<ISceneObject>();
    [SerializeField] private List<GameObject> _enemySpawners = new List<GameObject>();

    private Bullet _bullet;
    

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

    public void SetEnemySpawners()
    {
        
    }

    public Bullet CreateBullet()
    {
        _bullet = new Bullet(Instantiate(bulletPrefab), _bulletDamage, _baseBulletColor);
        return _bullet;
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}