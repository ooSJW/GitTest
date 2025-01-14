using UnityEngine;

public partial class SoundEffect : MonoBehaviour // DataField
{
    private float sfxVolume;
    private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] audioClips;

    private bool isPlay;
    public bool IsPlay { get { SetIsPlay(); return isPlay; } private set => isPlay = value; }
}
public partial class SoundEffect : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        sfxVolume = 0.3f;
        audioSources = new AudioSource[audioClips.Length];
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
            audioSources[i].volume = sfxVolume;
            audioSources[i].loop = false;
            audioSources[i].playOnAwake = false;
        }
        SetIsPlay();
    }
}
public partial class SoundEffect : MonoBehaviour // property
{
    private void SetIsPlay()
    {
        isPlay = MainSystem.Instance.DataManager.LoadVolume(SaveDataName.SFXVolume);
    }
    public void PlaySFX(SfxClipName clipName)
    {
        if (isPlay)
            audioSources[(int)clipName].Play();
    }
}
public partial class SoundEffect : MonoBehaviour // property
{
    private void GitTestMethod()
    {

    }
}