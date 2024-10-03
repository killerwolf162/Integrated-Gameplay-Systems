using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int damage { get; set; }
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public bool active { get; set; }

    public Bullet(int damage)
    {
        this.damage = damage;
    }

    public void Decorate(BulletDecorator decorator)
    {
        decorator.Decorate(this);   
    }

    public void ShootBullet()
    {
        Debug.Log("Shoot [" + string.Join(", ", elementalBulletTypes) + "] bullet dealing [" + damage + "] damage");
    }

    public void OnEnableObject()
    {
        Debug.Log("Render bullet in game");
    }

    public void OnDisableObject()
    {
        Debug.Log("stop rendering bullet in game");
    }
}
