using UnityEngine;

public partial class PlayerInput : MonoBehaviour // DataField
{
    private Player player;

    private Vector2 inputVector;
    public Vector2 InputVector { get => inputVector; }
}
public partial class PlayerInput : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        inputVector = Vector2.zero;
    }
    public void Initialize(Player palyerValue)
    {
        player = palyerValue;
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class PlayerInput : MonoBehaviour // Main
{
    public void Progress()
    {
        MoveInput();
    }
}
public partial class PlayerInput : MonoBehaviour // Property
{
    private void MoveInput()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        inputVector.Normalize();
    }
}