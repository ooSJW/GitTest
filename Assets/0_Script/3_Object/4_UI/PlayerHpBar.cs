using UnityEngine;
using UnityEngine.UI;

public partial class PlayerHpBar : MonoBehaviour // Data property
{
    private int playerHp;
    public int PlayerHp
    {
        get => playerHp;
        set
        {
            if (playerHp != value)
            {
                playerHp = value >= 0 ? value : 0;
                int maxHp = player.MaxHp;
                fillImage.fillAmount = (float)playerHp / maxHp;
            }
        }
    }
}
public partial class PlayerHpBar : MonoBehaviour // DataField
{
    private Player player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Image fillImage;
}
public partial class PlayerHpBar : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        player = MainSystem.Instance.PlayerManager.Player;
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        fillImage.fillAmount = (float)player.Hp / player.MaxHp;
    }
}
public partial class PlayerHpBar : MonoBehaviour // main
{
    private void Update()
    {
        if (player != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(player.transform.position + offset);
        }
        if (player.IsDead)
            gameObject.SetActive(false);
    }
}