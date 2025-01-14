using Unity.VisualScripting;
using UnityEngine;

public partial class BackGround : MonoBehaviour // DataField
{
    private float backGroundHeight;
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Test
    [SerializeField] private float scrollSpeed;
}
public partial class BackGround : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        backGroundHeight = spriteRenderer.bounds.size.y;
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.position = new Vector2(0, i * backGroundHeight);
        }
    }
}
public partial class BackGround : MonoBehaviour // Main
{
    private void Update()
    {
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
            if (background.transform.position.y < -backGroundHeight)
            {
                background.transform.position = new Vector2(0, backGroundHeight);
            }
        }
    }
}