using UnityEngine;

public partial class PlayerMovement : MonoBehaviour // DataField
{
    private Player player;
    private float moveSpeed;
}
public partial class PlayerMovement : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public void Initialize(Player playerValue)
    {
        player = playerValue;
        Allocate();
        Setup();
    }
    private void Setup()
    {
        moveSpeed = player.MoveSpeed;
    }
}
public partial class PlayerMovement : MonoBehaviour // Main
{
    public void FixedProgress()
    {
        /* Vector2 inputVector = player.PlayerInput.InputVector;
         if (inputVector != Vector2.zero)
         {
             transform.position += (Vector3)inputVector * Time.fixedDeltaTime * moveSpeed;
         }
        */

        Vector2 inputVector = MainSystem.Instance.UIManager.UIController.JoystickInput.GetInputVector();
        transform.position += (Vector3)inputVector * Time.fixedDeltaTime * moveSpeed;
    }
}