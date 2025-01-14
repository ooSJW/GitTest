using System;
using TMPro;
using UnityEngine;

public partial class UIController : MonoBehaviour // DataField
{
    [Header("InGameScene Member")]
    [field: SerializeField] public PauseUI PauseUI { get; private set; }
    [field: SerializeField] public PlayerUI PlayerUI { get; private set; }
    [field: SerializeField] public PlayerHpBar PlayerHpBar { get; private set; }
    [field: SerializeField] public JoystickInput JoystickInput { get; private set; }
    [field: SerializeField] public Dialog Dialog { get; private set; }

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverCurrentScoreText;

    [Header("LobbyScene Member")]
    [field: SerializeField] public LobbyUI LobbyUI { get; private set; }
    [field: SerializeField] public OptionUI OptionUI { get; private set; }
}
public partial class UIController : MonoBehaviour // Initialize
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
        SceneName activeSceneName = Enum.Parse<SceneName>(MainSystem.Instance.SceneManager.ActiveScene.name);
        switch (activeSceneName)
        {
            case SceneName.InGameScene:
                PauseUI.Initialize();
                PlayerUI.Initialize();
                PlayerHpBar.Initialize();
                JoystickInput.Initialize();
                gameOverUI.SetActive(false);
                Dialog.gameObject.SetActive(true);
                Dialog.Initialize();
                break;
            case SceneName.LobbyScene:
                LobbyUI.Initialize();
                OptionUI.Initialize();
                OptionUI.gameObject.SetActive(false);
                break;
        }
    }
}
public partial class UIController : MonoBehaviour // Property
{
    public void PauseGame()
    {
        PauseUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        int highScore = MainSystem.Instance.DataManager.ScoreSaveLoad();
        gameOverScoreText.text = $"최고 점수 : {highScore}";
        gameOverCurrentScoreText.text = $"현재 점수 : {PlayerUI.CurrentScore}";
        gameOverUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    /* public void OnOffOptionUI(bool? value = null)
     {
         bool result = value != null ? value.Value : !OptionUI.gameObject.activeSelf;
         OptionUI.gameObject.SetActive(result);
     }*/
    public void OnOffOptionUI()
    {
        OptionUI.gameObject.SetActive(!OptionUI.gameObject.activeSelf);
    }
}