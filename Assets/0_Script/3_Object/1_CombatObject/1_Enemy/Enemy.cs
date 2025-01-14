using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static EnemyData;

public partial class Enemy : CombatObjectBase // DataField
{
    [field: SerializeField] public EnemyMovement EnemyMovement { get; private set; } = default;
    [field: SerializeField] public EnemyCombat EnemyCombat { get; private set; } = default;

    private Transform target;
    public Transform Target { get => target; private set { target = value; } }
    private EnemyName enemyName;
}
public partial class Enemy : CombatObjectBase // Data Property
{
    private EnemyStatInformation enemyStatInformation;
    public EnemyStatInformation EnemyStatInformation
    {
        get => enemyStatInformation;
        private set
        {
            enemyStatInformation = new EnemyStatInformation()
            {
                index = value.index,
                name = value.name,
                moveSpeed = value.moveSpeed,
                maxHp = value.maxHp,
                damage = value.damage,
                dropScore = value.dropScore,
            };
            moveSpeed = value.moveSpeed;
            maxHp = value.maxHp;
            hp = value.maxHp;
            CalculateDamage(EnemyStatInformation);
        }
    }

    public override int Hp
    {
        get => hp;
        protected set
        {
            if (hp != value)
            {
                if (value > 0)
                {
                    hp = value;
                    MainSystem.Instance.SoundManager.SoundController.SoundEffect.PlaySFX(SfxClipName.Hit);
                }
                else
                {
                    hp = 0;
                    MainSystem.Instance.PoolManager.Spawn("Explosion", transform.position);
                    MainSystem.Instance.PoolManager.Despawn(gameObject);
                    MainSystem.Instance.PlayerManager.Player.Score += EnemyStatInformation.dropScore;
                    MainSystem.Instance.EnemyManager.SigndownEnemy(this);
                }

            }
        }
    }
}
public partial class Enemy : CombatObjectBase // Initialize
{
    private void Allocate()
    {
        enemyName = System.Enum.Parse<EnemyName>(name);
        EnemyStatInformation = MainSystem.Instance.DataManager.EnemyData.GetData(enemyName);
        Target = MainSystem.Instance.PlayerManager.Player.transform;
    }
    public override void Initialize()
    {
        base.Initialize();
        Allocate();
        Setup();

        EnemyMovement.Initialize(this);
        EnemyCombat.Initialize(this);
    }
    private void Setup()
    {

    }
}
public partial class Enemy : CombatObjectBase // Main
{
    private void FixedUpdate()
    {
        EnemyMovement.FixedProgress();
    }
}