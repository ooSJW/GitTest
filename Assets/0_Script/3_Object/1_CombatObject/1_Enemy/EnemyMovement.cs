using UnityEngine;

public partial class EnemyMovement : MonoBehaviour // DataField
{
    private Enemy enemy;
    [SerializeField] private Rigidbody2D rigid;
    private Vector2 direction;
    // TEST
    private float moveSpeed;
}
public partial class EnemyMovement : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        moveSpeed = enemy.MoveSpeed;
    }
    public void Initialize(Enemy enemyValue)
    {
        enemy = enemyValue;
        Allocate();
        Setup();
    }
    private void Setup()
    {
        direction = (enemy.Target.transform.position - transform.position).normalized;
    }
}
public partial class EnemyMovement : MonoBehaviour // Main
{
    public void FixedProgress()
    {
        if (enemy.Target != null)
        {
            transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}