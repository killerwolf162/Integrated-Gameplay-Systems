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

    private IShooter _shooter;

    private Rigidbody2D _rig;
    private SpriteRenderer _rend;

    public float timer = 0f;
    public float timeOutTime = 2f;

    private int _bulletSpeed = 10;

    public Bullet(GameObject bulletPrefab, IShooter shooter, int damage, Color color)
    {
        bullet = bulletPrefab;
        this.damage = damage;
        this.color = color;
        _shooter = shooter;
    }

    public void Start()
    {
        OnDisableObject();

        if (_rig == null)
            _rig = bullet.GetComponent<Rigidbody2D>();
        if (_rend == null)
            _rend = bullet.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeOutTime)
        {
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

    public void OnEnableObject()
    {
        bullet.SetActive(true);
        GameHandler.instance.Subscribe(this);

        bullet.transform.position = _shooter.GameObject().transform.position;
        bullet.transform.rotation = _shooter.GetBulletRotation(bullet);

        _rend.color = color;
        _rig.AddForce(_shooter.GetAimDirection(bullet).normalized * _bulletSpeed, ForceMode2D.Impulse);
    }

    public void OnDisableObject()
    {
        GameHandler.instance.UnSubscribe(this);
        bullet.SetActive(false);

        timer = 0;
    }

}
