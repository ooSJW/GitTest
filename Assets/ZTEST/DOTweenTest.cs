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

        // UI�� �����ؼ� DOAnchor���, �Ϲ� ������ƮDOMove();
        // Ease (easing function) : �ִϸ��̼��� ���� �ӵ��� �����ϴ� ���, �ڿ������� �����Ӱ� �ð��� ������ ����� ���� �����.
        rectTransform.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InOutQuad);
        rectTransform.DOScale(3, 0.7f);
    }
}