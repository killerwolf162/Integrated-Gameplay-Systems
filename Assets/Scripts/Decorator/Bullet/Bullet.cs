using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int damage { get; set; }
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };

    public Bullet(int damage)
    {
        this.damage = damage;
    }

    public void Decorate(BulletDecorator decorator)
    {
        decorator.Decorate(this);   
    }

    public void Fire()
    {
        Debug.Log("Cast [" + string.Join(", ", elementalBulletTypes) + "] bullet dealing [" + damage + "] damage");
    }
}
