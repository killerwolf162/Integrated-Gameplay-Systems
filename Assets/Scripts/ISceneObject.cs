using UnityEngine;

public interface ISceneObject
{
    public GameObject gameobject { get; }

    public abstract void Start();
    public abstract void Update();
}
