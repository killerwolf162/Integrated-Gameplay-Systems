using System;
using UnityEngine;

[Serializable]
public class Unit : IAbilityActor
{
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual GameObject GameObject()
    {
        return null;
    }

    public virtual Vector2 GetAimDirection()
    {
        return new Vector2(0f, 0f);
    }

    public virtual Vector2 MoveDirection()
    {
        return new Vector2(0f, 0f);
    }
}
