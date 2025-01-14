using UnityEngine;
using UnityEngine.EventSystems;

public partial class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler // DataField
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandler;
    private Vector2 inputDirection;
}
public partial class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler // Initialize
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
public partial class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler // Property
{
    public Vector2 GetInputVector()
    {
        return inputDirection;
    }
}
public partial class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler // Drag
{
    public void OnEndDrag(PointerEventData eventData)
    {
        joystickHandler.localPosition = Vector2.zero;
        inputDirection = Vector2.zero;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - (Vector2)joystickBackground.position;
        if (direction.magnitude > joystickBackground.rect.width * 0.5f)
            direction = direction.normalized * (joystickBackground.rect.width * 0.5f);

        joystickHandler.localPosition = direction;
        inputDirection = direction.normalized;
    }
}