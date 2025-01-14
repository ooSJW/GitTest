using UnityEngine;

public partial class PlayerCombat : MonoBehaviour // DataField
{
    private Player player;
    private float intervalTime;
}
public partial class PlayerCombat : MonoBehaviour // DataField
{

}
public partial class PlayerCombat : MonoBehaviour // Initialize
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

    }
}
public partial class PlayerCombat : MonoBehaviour // Property
{
    public void Progress()
    {
        CoolTime();
    }
}
public partial class PlayerCombat : MonoBehaviour // Property
{
    public void CoolTime()
    {
        if (player.IsCoolling)
        {
            intervalTime += Time.deltaTime;
            if (intervalTime >= player.AttackDealy)
            {
                player.IsCoolling = false;
                intervalTime = 0;
            }
        }
        Attack();
    }
    public void Attack()
    {
        if (!player.IsCoolling)
        {
            Bullet bullet = MainSystem.Instance.PoolManager.Spawn(BulletName.SmallBullet.ToString(), transform.position).GetComponent<Bullet>();
            bullet.Initialize(player);
            MainSystem.Instance.SoundManager.SoundController.SoundEffect.PlaySFX(SfxClipName.PlayerAttack);

            player.IsCoolling = true;
        }
    }
}