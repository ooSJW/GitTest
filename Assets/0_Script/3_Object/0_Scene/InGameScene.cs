using UnityEngine;

public partial class InGameScene : BaseScene // DataField
{
    [field: SerializeField] public Player Player { get; private set; } = default;
    [field: SerializeField] public SpawnController SpawnController { get; private set; } = default;
    [field: SerializeField] public BackGroundController BackGroundController { get; private set; } = default;
    [field: SerializeField] public UIController UIController { get; private set; } = default;

}
public partial class InGameScene : BaseScene // Initialize
{
    private void Allocate()
    {

    }
    public override void Initialize()
    {
        base.Initialize();

        Allocate();
        Setup();
        Time.timeScale = 0f;
    }
    private void Setup()
    {
        MainSystem.Instance.PoolManager.Register();
        MainSystem.Instance.SpawnManager.SignupSpawnController(SpawnController);
        MainSystem.Instance.PlayerManager.SignupPlayer(Player);
        MainSystem.Instance.BackGroundManager.SignupBackGroundController(BackGroundController);
        MainSystem.Instance.UIManager.SignupUIController(UIController);
        MainSystem.Instance.SoundManager.SignupSoundController(SoundController);
    }
}
public partial class InGameScene : BaseScene // Property
{
    public void LoadLobbyScene()
    {
        MainSystem.Instance.SceneManager.LoadScene(SceneName.LobbyScene);
    }
}