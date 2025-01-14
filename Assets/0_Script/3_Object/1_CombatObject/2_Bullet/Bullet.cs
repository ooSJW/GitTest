using System;
using Unity.VisualScripting;
using UnityEngine;
using static BulletData;

public partial class Bullet : MonoBehaviour // DataField
{
    private BulletName bulletName;
    [SerializeField] private Rigidbody2D rigid;
    public int Damage { get; private set; }
    public float MoveSpeed { get; private set; }
    private Player owner;
}
public partial class Bullet : MonoBehaviour // Data Property
{
    private BulletInformation bulletInformation;
    public BulletInformation BulletInformation
    {
        get => bulletInformation;
        private set
        {
            bulletInformation = new BulletInformation
            {
                index = value.index,
                name = value.name,
                damage = value.damage,
                moveSpeed = value.moveSpeed,
            };
            MoveSpeed = value.moveSpeed;
            Damage = value.damage;
        }
    }
}
public partial class Bullet : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        bulletName = Enum.Parse<BulletName>(gameObject.name);
        BulletInformation = MainSystem.Instance.DataManager.BulletData.GetData(bulletName);
    }
    public void Initialize(Player player)
    {
        owner = player;
        Allocate();
        Setup();
        Shoot();
    }
    private void Setup()
    {

    }
}
public partial class Bullet : MonoBehaviour // Property
{
    private void Shoot()
    {
        rigid.AddForce(Vector2.up * MoveSpeed, ForceMode2D.Impulse);
    }
}
public partial class Bullet : MonoBehaviour // Trigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy hitEnemy = collision.GetComponent<Enemy>();
            if (hitEnemy != null)
                owner.SendDamage(hitEnemy, owner.PlayerInformation, Damage);
        }
        MainSystem.Instance.PoolManager.Despawn(gameObject);
    }
}

