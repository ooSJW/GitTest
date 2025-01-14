using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class EnemyData  // Inner Class
{
    [System.Serializable]
    public class EnemyStatInformation : CombatObjectInformation
    {
        public string name;
        public int dropScore;
    }
}
public partial class EnemyData  // DataField
{
    private Dictionary<string, EnemyStatInformation> enemyInfoDict;
}
public partial class EnemyData // Initialize
{
    private void Allocate()
    {
        enemyInfoDict = new Dictionary<string, EnemyStatInformation>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        MainSystem.Instance.DataManager.SetupData<EnemyStatInformation>(enemyInfoDict, "EnemyData");
    }
}
public partial class EnemyData // property
{
    public EnemyStatInformation GetData(string index)
    {
        return enemyInfoDict[index];
    }
    public EnemyStatInformation GetData(EnemyName name)
    {
        return enemyInfoDict.Values.Where(elem => elem.name == name.ToString()).FirstOrDefault();
    }
}