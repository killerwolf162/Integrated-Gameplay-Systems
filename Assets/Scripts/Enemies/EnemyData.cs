using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    //all enemy data stored for easy enemy modification
    public string enemyName { get; private set; } = "DefaultEnemy";
    public float moveSpeed { get; private set; } = 10f;
    public int damage { get; private set; } = 1;
    public int health { get; private set; } = 3;
}
