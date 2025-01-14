using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public partial class OptionUI : MonoBehaviour // DataField
{
    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;
    [SerializeField] private Button bgmButton;
    [SerializeField] private Button sfxButton;
}
public partial class OptionUI : MonoBehaviour // Initialize
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
        bool currentVolume = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.BGMVolume);
        Sprite resultSprite = null;

        if (currentVolume)
            resultSprite = onImage;
        else
            resultSprite = offImage;

        bgmButton.image.sprite = resultSprite;

        currentVolume = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.SFXVolume);
        if (currentVolume)
            resultSprite = onImage;
        else
            resultSprite = offImage;

        sfxButton.image.sprite = resultSprite;
    }
}
public partial class OptionUI : MonoBehaviour // Property
{
    public void OnOffBgm()
    {
        MainSystem.Instance.DataManager.SaveVolume(SaveDataName.BGMVolume);
        bool currentVolume = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.BGMVolume);
        Sprite resultSprite = null;
        if (currentVolume)
            resultSprite = onImage;
        else
            resultSprite = offImage;

        bgmButton.image.sprite = resultSprite;
    }
    public void OnOffSfx()
    {
        MainSystem.Instance.DataManager.SaveVolume(SaveDataName.SFXVolume);
        bool currentVolume = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.SFXVolume);
        Sprite resultSprite = null;
        if (currentVolume)
            resultSprite = onImage;
        else
            resultSprite = offImage;

        sfxButton.image.sprite = resultSprite;
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey(SaveDataName.HighestScore.ToString());
        MainSystem.Instance.UIManager.UIController.LobbyUI.SetScoreText();
    }
}