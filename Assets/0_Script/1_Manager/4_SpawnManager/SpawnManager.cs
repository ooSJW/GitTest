using UnityEngine;

public partial class SpawnManager : MonoBehaviour // DataField
{
    public SpawnController SpawnController { get; private set; } = default;
}
public partial class SpawnManager : MonoBehaviour // Initialize
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
public partial class SpawnManager : MonoBehaviour // Sign
{
    public void SignupSpawnController(SpawnController spawnControllerValue)
    {
        SpawnController = spawnControllerValue;
        SpawnController.Initialize();
    }
    public void SigndownSpawnController()
    {
        SpawnController = null;
    }
}