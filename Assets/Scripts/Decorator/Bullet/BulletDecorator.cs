public abstract class BulletDecorator
{
    public int damage { get; set; }

    public BulletDecorator()
    {

    }

    public abstract IBullet Decorate(IBullet bullet);

}

public class ElementDecorator : BulletDecorator
{
    private ElementalBulletTypes bulletType;

    public ElementDecorator(ElementalBulletTypes bulletType)
    {
        this.bulletType = bulletType;
    }

    public override IBullet Decorate(IBullet bullet)
    {
        bullet.elementalBulletTypes.Add(bulletType);
        bullet.damage += damage;
        return bullet;
    }

}

