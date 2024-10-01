using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script is only here to test the decorator function

public class BulletPlayerTest : MonoBehaviour
{

    Bullet bullet;
    private int fireDamage = 5;
    private int iceDamage = 5;

    void Start()
    {
        bullet = new Bullet(5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bullet.Fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bullet.Decorate(new ElementDecorator(ElementalBulletTypes.Fire, fireDamage));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bullet.Decorate(new ElementDecorator(ElementalBulletTypes.Ice, iceDamage));
        }
    }
}
