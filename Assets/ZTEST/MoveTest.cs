using System.Collections;
using UnityEngine;

public partial class MoveTest : MonoBehaviour // DataField
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Collider catCollider;
    private Collider lastDetectCollider;
}
public partial class MoveTest : MonoBehaviour // Initialize
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
public partial class MoveTest : MonoBehaviour // Property
{
    public void Jump()
    {
        if (lastDetectCollider)
            Physics.IgnoreCollision(lastDetectCollider, catCollider, true);

        rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        StartCoroutine(ReenanleCollisiion());
    }
}

public partial class MoveTest : MonoBehaviour // Unity Main
{
    private IEnumerator ReenanleCollisiion()
    {
        yield return new WaitForSeconds(0.2f);
        if (lastDetectCollider)
            Physics.IgnoreCollision(lastDetectCollider, catCollider, false);
    }
}

public partial class MoveTest : MonoBehaviour // Unity Main
{
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveVec = new Vector3(moveX, 0, moveZ);
        rigid.AddForce(moveVec.normalized * moveSpeed, ForceMode.Impulse);
        if (Input.GetButtonDown("Jump"))
            Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
            lastDetectCollider = collision.collider;
    }
}