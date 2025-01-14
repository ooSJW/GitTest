using UnityEngine;

public partial class EnemyCombat : MonoBehaviour // DataField
{
    private Enemy enemy;
}
public partial class EnemyCombat : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public void Initialize(Enemy enemyValue)
    {
        enemy = enemyValue;
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class EnemyCombat : MonoBehaviour // 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                Player player = collision.GetComponent<Player>();
                enemy.SendDamage(player, enemy.EnemyStatInformation);
            }
            if (collision.CompareTag("Border"))
            {
                MainSystem.Instance.EnemyManager.SigndownEnemy(enemy);
                MainSystem.Instance.PoolManager.Despawn(gameObject);
            }
        }
    }
}