using UnityEngine;

public partial class BackGroundManager : MonoBehaviour // DataField
{
    public BackGroundController BackGroundController { get; private set; }
}
public partial class BackGroundManager : MonoBehaviour // Initialize
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
public partial class BackGroundManager : MonoBehaviour // Sign
{
    public void SignupBackGroundController(BackGroundController backGroundManagerValue)
    {
        BackGroundController = backGroundManagerValue;
        BackGroundController.Initialize();
    }
}