using UnityEngine;

public partial class BackgroundMusic : MonoBehaviour // DataField
{
    private AudioSource bgmPlayer;
    [SerializeField] private AudioClip bgm;
}
public partial class BackgroundMusic : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        bool isPlay = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.BGMVolume);
        bgmPlayer.clip = bgm;
        bgmPlayer.loop = true;
        bgmPlayer.volume = 0.5f;
        bgmPlayer.playOnAwake = isPlay;
        OnOffBgm();
    }
}
public partial class BackgroundMusic : MonoBehaviour // Property
{
    public void OnOffBgm()
    {
        bool isPlay = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.BGMVolume);
        if (isPlay)
            bgmPlayer.Play();
        else
            bgmPlayer.Pause();
    }
}