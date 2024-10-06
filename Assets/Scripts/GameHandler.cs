using PlayerNS;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField] private GameObject _playerPrefab;

    public ISceneObject player;

    public Camera mainCam;

    private List<IUpdateable> _updateables = new List<IUpdateable>();

    private void Start()
    {
        instance = this;
        player = new PlayerController(Instantiate(_playerPrefab));
        mainCam = FindAnyObjectByType<Camera>();       
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
}