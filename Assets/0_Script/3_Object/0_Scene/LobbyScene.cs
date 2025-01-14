using TMPro;
using UnityEngine;

public partial class LobbyScene : BaseScene // DataField
{
    [field: SerializeField] public UIController UIController { get; private set; } = default;
}
public partial class LobbyScene : BaseScene // Initialize
{
    private void Allocate()
    {

    }
    public override void Initialize()
    {
        base.Initialize();

        Allocate();
        Setup();
    }
    private void Setup()
    {
        MainSystem.Instance.UIManager.SignupUIController(UIController);
        MainSystem.Instance.SoundManager.SignupSoundController(SoundController);
    }
}
public partial class LobbyScene : BaseScene // property
{
    public void LoadInGameScene()
    {
        MainSystem.Instance.SceneManager.LoadScene(SceneName.InGameScene);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}