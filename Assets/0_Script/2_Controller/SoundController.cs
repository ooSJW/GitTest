using UnityEngine;

public partial class SoundController : MonoBehaviour // DataField
{
    [field: SerializeField] public BackgroundMusic BackgroundMusic { get; private set; }
    [field: SerializeField] public SoundEffect SoundEffect { get; private set; }
}
public partial class SoundController : MonoBehaviour // Initialize
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
        BackgroundMusic.Initialize();
        SoundEffect.Initialize();
    }
}
public partial class SoundController : MonoBehaviour // 
{

}