using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet, ISceneObject
{
    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; } = new HashSet<ElementalBulletTypes>() { ElementalBulletTypes.Normal };
    public int damage { get; set; }
    public Color color { get; set; }
    public bool active { get; set; }

    public event Action<Bullet> OnDie;

    public GameObject gameobject => bullet;
    public GameObject bullet;

    public float timer = 0f;
    public float timeOutTime = 2f;

    private Rigidbody2D _rig;
    private SpriteRenderer _rend;

    public Bullet(GameObject bulletPrefab, int damage, Color color)
    {
        bullet = bulletPrefab;
        this.damage = damage;
        this.color = color;       
    }

    public void Start()
    {
        GameHandler.instance.CreateBullet(bullet);
        if (_rig == null)
            _rig = bullet.GetComponent<Rigidbody2D>();
        if (_rend == null)
            _rend = bullet.GetComponent<SpriteRenderer>();

        bullet.SetActive(false);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeOutTime)
        {
            Debug.Log("I die");
            Die();
        }
    }

    public void Die()
    {
        OnDie?.Invoke(this);
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
        bullet.SetActive(true);
        GameHandler.instance.Subscribe(this);      

        _rend.color = color;
        _rig.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    public void OnDisableObject()
    {
        GameHandler.instance.UnSubscribe(this);
        bullet.SetActive(false);

        OnDie = null;
    }

}
