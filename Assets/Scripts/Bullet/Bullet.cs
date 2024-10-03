using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int damage { get; set; }
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public Color color { get; set; }
    public bool active { get; set; }

    public GameObject gameobject => bullet;

    public GameObject bullet;

    private Rigidbody2D _rig;
    private SpriteRenderer _rend;

    public Bullet(int damage, Color color)
    {
        this.damage = damage;
        this.color = color;       
    }

    public void Decorate(BulletDecorator decorator)
    {
        decorator.Decorate(this);   
    }

    public void ShootBullet()
    {
        Debug.Log("I shoot");
        bullet = GameHandler.instance.CreateBullet();
        _rig = bullet.GetComponent<Rigidbody2D>(); // this is bad, getcomponent everytime you shoot a bullet, need to rework if time
        _rend = bullet.GetComponent<SpriteRenderer>();
        _rend.color = this.color;
        _rig.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    public void OnEnableObject()
    {
        ShootBullet();
        
    }

    public void OnDisableObject()
    {
        bullet.SetActive(false);
    }
}
