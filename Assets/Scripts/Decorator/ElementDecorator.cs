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
        if (bullet.elementalBulletTypes.Contains(bulletType))
        {
            Debug.Log("This bullet already has this type");
            return bullet;
        }
        if (bullet.elementalBulletTypes.Contains(ElementalBulletTypes.Normal)) // check if bullet is not decorated
        {
            bullet.elementalBulletTypes.Add(bulletType);
            bullet.elementalBulletTypes.Remove(ElementalBulletTypes.Normal);
            bullet.damage += damage;
            bullet.color = color;
            Debug.Log("Decorate bullet with [" + string.Join(", ", bulletType) + "]");
            return bullet;
        }

        else // if bullet is already decorted with same or other decoration, return
        {
            Debug.Log("Bullet type switched to " + "[" + bulletType + "]") ;
            bullet.elementalBulletTypes.Clear();
            bullet.elementalBulletTypes.Add(bulletType);
            bullet.color = color;
            return bullet;
        }      
    }
}

