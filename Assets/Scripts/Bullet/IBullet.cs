using System.Collections.Generic;

public interface IBullet : IPoolable
{
    int damage { get; set; }

    HashSet<ElementalBulletTypes> elementalBulletTypes { get; set; }

    void Decorate(BulletDecorator decorator);

    void ShootBullet();
}

