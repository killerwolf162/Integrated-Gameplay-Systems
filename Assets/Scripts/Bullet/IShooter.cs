using UnityEngine;

public interface IShooter
{

    public abstract GameObject GameObject();
    public abstract Vector2 GetAimDirection(GameObject objectToAim);
    public abstract Quaternion GetBulletRotation(GameObject objectToAim);

}

