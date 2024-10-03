using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet, ISceneObject
{
    public int damage { get; set; }
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public Color color { get; set; }
    public bool active { get; set; }

    public GameObject gameobject => bullet;

    public GameObject bullet;

    private Rigidbody2D rig;
    private SpriteRenderer rend;

    public Bullet(int damage, Color color)
    {
        this.damage = damage;
        this.color = color;
        Start();
        
    }

    public void Decorate(BulletDecorator decorator)
    {
        decorator.Decorate(this);   
    }

    public void ShootBullet()
    {
        Debug.Log("I shoot");
    }

    public void OnEnableObject()
    {
        Debug.Log("I got enabeld");
        bullet = GameHandler.instance.CreateBullet();
        rig = bullet.GetComponent<Rigidbody2D>();
        rend = bullet.GetComponent<SpriteRenderer>();
        rend.color = this.color;
        rig.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    public void OnDisableObject()
    {
        bullet.SetActive(false);
    }

    public void Start()
    {
        GameHandler.instance.Subscribe(this);
        
    }

    public void Update()
    {

    }
}
