using UnityEngine;

public partial class SoundManager : MonoBehaviour // DataField
{
    public SoundController SoundController { get; private set; }
}
public partial class SoundManager : MonoBehaviour // Initialize
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
public partial class SoundManager : MonoBehaviour // Sign
{
    public void SignupSoundController(SoundController soundControllerValue)
    {
        SoundController = soundControllerValue;
        SoundController.Initialize();
    }
    public void SigndownSoundController()
    {
        SoundController = null;
    }
}