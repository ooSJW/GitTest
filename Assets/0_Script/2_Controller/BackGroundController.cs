using UnityEngine;

public partial class BackGroundController : MonoBehaviour // DataField
{
    [field: SerializeField] public BackGround BackGround { get; private set; }
}
public partial class BackGroundController : MonoBehaviour // Initialize
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
        BackGround.Initialize();
    }
}
public partial class BackGroundController : MonoBehaviour // 
{

}