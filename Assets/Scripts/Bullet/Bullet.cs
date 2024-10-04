using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet, ISceneObject
{
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public int damage { get; set; }
    public Color color { get; set; }
    public bool active { get; set; }

    public GameObject gameobject => bullet;
    public GameObject bullet;

    public float timer = 0f;
    public float timeOutTime = 2f;

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
        Start();      
    }
    public void OnEnableObject()
    {
        ShootBullet();      
    }
    public void OnDisableObject()
    {
        GameHandler.instance.DestroyObject(bullet);
        GameHandler.instance.UnSubscribe(this);
        timer = 0;
    }
    public void Start()
    {
        GameHandler.instance.Subscribe(this);
        bullet = GameHandler.instance.CreateBullet();

        if(_rig == null)
            _rig = bullet.GetComponent<Rigidbody2D>();
        if(_rend == null)
            _rend = bullet.GetComponent<SpriteRenderer>();

        _rend.color = this.color;
        _rig.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        Update();
    }
    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeOutTime)
        {
            bullet.SetActive(false);
        }
    }
}
