using UnityEngine;
using UnityEngine.SceneManagement;

public partial class MainSystem : GenericSingleton<MainSystem> // DataField
{
    public SceneManager SceneManager { get; private set; } = default;
    public DataManager DataManager { get; private set; } = default;
    public PoolManager PoolManager { get; private set; } = default;
    public SpawnManager SpawnManager { get; private set; } = default;
    public PlayerManager PlayerManager { get; private set; } = default;
    public EnemyManager EnemyManager { get; private set; } = default;
    public BackGroundManager BackGroundManager { get; private set; } = default;
    public UIManager UIManager { get; private set; } = default;
    public SoundManager SoundManager { get; private set; } = default;
}
public partial class MainSystem : GenericSingleton<MainSystem> // Initialize
{
    private void Allocate()
    {
        SceneManager = gameObject.AddComponent<SceneManager>();
        DataManager = gameObject.AddComponent<DataManager>();
        PoolManager = gameObject.AddComponent<PoolManager>();
        SpawnManager = gameObject.AddComponent<SpawnManager>();
        PlayerManager = gameObject.AddComponent<PlayerManager>();
        EnemyManager = gameObject.AddComponent<EnemyManager>();
        BackGroundManager = gameObject.AddComponent<BackGroundManager>();
        UIManager = gameObject.AddComponent<UIManager>();
        SoundManager = gameObject.AddComponent<SoundManager>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();

        SceneManager.Initialize();
        DataManager.Initialize();
        PoolManager.Initialize();
        SpawnManager.Initialize();
        PlayerManager.Initialize();
        EnemyManager.Initialize();
        BackGroundManager.Initialize();
        UIManager.Initialize();
        SoundManager.Initialize();
    }
    private void Setup()
    {

    }
}
public partial class MainSystem : GenericSingleton<MainSystem> // MainSystemStart
{
    public void MainSystemStart()
    {
        Initialize();
        SceneManager.LoadScene(SceneName.LobbyScene);
        print("MainSystemStart");
    }
}