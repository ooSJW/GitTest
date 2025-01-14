using System.Collections;
using UnityEngine;
using static PlayerData;

public partial class Player : CombatObjectBase // DataField
{
    [field: SerializeField] public PlayerInput PlayerInput { get; private set; }
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerCombat PlayerCombat { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask layerMask;

    private int score;
    public int Score
    {
        get => score;
        set
        {
            if (score != value)
            {
                score = value;
                MainSystem.Instance.UIManager.UIController.PlayerUI.SetScore(score);
            }
        }
    }
}
public partial class Player : CombatObjectBase // Data Property
{
    private PlayerInformation playerInformation;
    public PlayerInformation PlayerInformation
    {
        get => playerInformation;
        private set
        {
            playerInformation = new PlayerInformation()
            {
                index = value.index,
                maxHp = value.maxHp,
                attackDelay = value.attackDelay,
                damage = value.damage,
                moveSpeed = value.moveSpeed,
            };
            moveSpeed = value.moveSpeed;
            hp = value.maxHp;
            maxHp = value.maxHp;
            moveSpeed = value.moveSpeed;
            AttackDealy = value.attackDelay;
            CalculateDamage(PlayerInformation);
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
                    gameObject.layer = LayerMask.NameToLayer("HitPlayer");
                    animator.SetTrigger("PlayerHit");
                }
                else
                {
                    hp = 0;
                    IsDead = true;
                    gameObject.SetActive(false);
                    MainSystem.Instance.PoolManager.Spawn("Explosion", transform.position);
                }

                MainSystem.Instance.UIManager.UIController.PlayerHpBar.PlayerHp = hp;
            }
        }
    }
    private bool isCoolling;
    public bool IsCoolling
    {
        get => isCoolling;
        set
        {
            if (IsCoolling != value)
            {
                isCoolling = value;
            }
        }
    }
    private bool isDead;
    public bool IsDead
    {
        get => isDead;
        private set
        {
            isDead = value;
            if (isDead)
                MainSystem.Instance.PlayerManager.PlayerDead(Score);
        }
    }
    public float AttackDealy { get; private set; }
}

public partial class Player : CombatObjectBase // Initialize
{
    private void Allocate()
    {
        PlayerInformation = MainSystem.Instance.DataManager.PlayerData.GetData("0");
        isDead = false;
        isCoolling = true;
    }
    public override void Initialize()
    {
        base.Initialize();

        Allocate();
        Setup();

        PlayerInput.Initialize(this);
        PlayerMovement.Initialize(this);
        PlayerCombat.Initialize(this);
    }
    private void Setup()
    {

    }
}
public partial class Player : CombatObjectBase // Main
{
    private void Update()
    {
        if (!isDead)
        {
            PlayerInput.Progress();
            PlayerCombat.Progress();
        }
    }
    private void FixedUpdate()
    {
        if (!isDead)
            PlayerMovement.FixedProgress();
    }
}
public partial class Player : CombatObjectBase // Property
{
    public void ReturnLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}