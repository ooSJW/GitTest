using UnityEngine;

public partial class CombatObjectBase : MonoBehaviour // DataField
{
    protected int maxHp;
    public virtual int MaxHp { get => maxHp; protected set => maxHp = value; }

    protected int hp;
    public virtual int Hp { get => hp; protected set => hp = value; }


    protected float moveSpeed;
    public virtual float MoveSpeed { get => moveSpeed; protected set => moveSpeed = value; }

    protected int totalDamage;
}
public partial class CombatObjectBase : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public virtual void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class CombatObjectBase : MonoBehaviour // Property
{
    public void CalculateDamage(CombatObjectInformation statInfo)
    {
        totalDamage = statInfo.damage;
    }

    public virtual void SendDamage(CombatObjectBase target, CombatObjectInformation sender, float weaponDamage = 0)
    {
        float resultDamage = totalDamage + weaponDamage;
        target.ReceiveDamage((int)resultDamage);
    }

    public void ReceiveDamage(int damage)
    {
        if (Hp > 0)
            Hp -= damage;
    }
}