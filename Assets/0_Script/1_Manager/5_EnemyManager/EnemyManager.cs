using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyManager : MonoBehaviour // DataField
{
    public List<Enemy> AllFieldEnemyList { get; private set; }
}
public partial class EnemyManager : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        AllFieldEnemyList = new List<Enemy>();
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
public partial class EnemyManager : MonoBehaviour // Sign
{
    public void SignupEnemy(Enemy enemyValue)
    {
        AllFieldEnemyList.Add(enemyValue);
        enemyValue.Initialize();
    }
    public void SigndownEnemy(Enemy enemyValue)
    {
        if (AllFieldEnemyList.Contains(enemyValue))
            AllFieldEnemyList.Remove(enemyValue);
    }
}