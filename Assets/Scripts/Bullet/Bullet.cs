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

    private Camera _mainCam;
    private Vector3 mousePos;

    private int _bulletSpeed = 10;

    public Bullet(GameObject bulletPrefab, int damage, Color color)
    {
        bullet = bulletPrefab;
        this.damage = damage;
        this.color = color;       
    }

    public void Start()
    {
        _mainCam = GameHandler.instance.mainCam;

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

    public void ShootBullet()
    {
    }

    public void OnEnableObject()
    {
        bullet.SetActive(true);
        GameHandler.instance.Subscribe(this);

        bullet.transform.position = _mainCam.transform.position + new Vector3(0,0,1);

        bullet.transform.rotation = GetBulletRotation();

        _rend.color = color;
        _rig.AddForce(GetAimDirection().normalized * _bulletSpeed, ForceMode2D.Impulse);
    }

    public void OnDisableObject()
    {
        GameHandler.instance.UnSubscribe(this);
        bullet.SetActive(false);

        timer = 0;
    }

    public Vector3 GetAimDirection()
    {
        mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        var directionToGive = mousePos - bullet.transform.position;

        return directionToGive;
    }

    public Quaternion GetBulletRotation()
    {
        mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - bullet.transform.position;
        float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        return Quaternion.Euler(0, 0, zRotation - 90);
    }

}
