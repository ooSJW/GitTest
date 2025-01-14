using DG.Tweening;
using UnityEngine;
public partial class DOTweenTest : MonoBehaviour // DataField
{

}
public partial class DOTweenTest : MonoBehaviour // Initialize
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
public partial class DOTweenTest : MonoBehaviour // 
{
    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        // UI에 부착해서 DOAnchor사용, 일반 오브젝트DOMove();
        // Ease (easing function) : 애니메이션의 진행 속도를 제어하는 방법, 자연스러운 움직임과 시각적 만족도 향상을 위해 사용함.
        rectTransform.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InOutQuad);
        rectTransform.DOScale(3, 0.7f);
    }
}