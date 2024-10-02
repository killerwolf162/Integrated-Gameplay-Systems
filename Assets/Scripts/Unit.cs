using UnityEngine;

public class Unit : MonoBehaviour, IAbilityActor
{
    public virtual GameObject GameObject()
    {
        return gameObject;
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
