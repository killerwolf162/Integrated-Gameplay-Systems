using UnityEngine;

public class ElementDecorator : BulletDecorator
{
    private ElementalBulletTypes bulletType;
    private Color color;

    public ElementDecorator(ElementalBulletTypes bulletType, int damage, Color color)
    {
        this.bulletType = bulletType;
        this.damage = damage;
        this.color = color;
 
    }

    public override IBullet Decorate(IBullet bullet)
    {
        if(bullet.elementalBulletTypes.Contains(bulletType)) // checks if bullet has already been decorated
        {
            Debug.Log("Bullet already has this effect");
            return bullet;
        }
        else
        {
            bullet.elementalBulletTypes.Add(bulletType); //if bullet hasnt been decorated by this decorater, decorate
            bullet.damage += damage;
            bullet.color = color;
            Debug.Log("Decorate bullet with [" + string.Join(", ", bulletType) + "]");
            return bullet;
        }      
    }
}

