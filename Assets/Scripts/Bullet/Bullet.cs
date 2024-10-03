using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int damage { get; set; }
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public bool active { get; set; }
    public GameObject bulletPrefab;

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
        // Shoot Bullet
    }

    public void OnEnableObject()
    {
        // render bullet in game
    }

    public void OnDisableObject()
    {
        // stop rendering bullet in game
    }
}
