using System.Collections.Generic;

public interface IBullet : IPoolable
{
    public int damage { get; set; }

    public HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; }

    public void Decorate(BulletDecorator decorator);

    public void ShootBullet();
}

