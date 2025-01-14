using UnityEngine;

public partial class Spawner : MonoBehaviour // DataField
{
    [SerializeField] private Transform[] spawnPoints;
    // TEST
    [SerializeField] private float spawnTime;
    private float intervalTime;
}
public partial class Spawner : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class Spawner : MonoBehaviour // Main
{
    private void Update()
    {
        intervalTime += Time.deltaTime;
        if (intervalTime >= spawnTime)
        {
            RandomSpawn();
            intervalTime = 0;
        }
    }
}

public partial class Spawner : MonoBehaviour // Property
{
    public void RandomSpawn()
    {
        Player player = MainSystem.Instance.PlayerManager.Player;
        if (player != null && player.IsDead == false)
        {
            int randomPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            Vector2 resultPosition = spawnPoints[randomPoint].position;
            Enemy enemy = MainSystem.Instance.PoolManager.Spawn(EnemyName.Enemy01.ToString(), resultPosition).GetComponent<Enemy>();
            MainSystem.Instance.EnemyManager.SignupEnemy(enemy);
        }
    }
}