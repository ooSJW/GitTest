using UnityEngine;

public partial class SpawnController : MonoBehaviour // DataField
{
    [field: SerializeField] public Spawner Spawner { get; private set; } = default;
}
public partial class SpawnController : MonoBehaviour // Initialize
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
public partial class SpawnController : MonoBehaviour // 
{

}