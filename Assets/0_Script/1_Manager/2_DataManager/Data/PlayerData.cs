using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public partial class PlayerData
{
    [System.Serializable]
    public class PlayerInformation : CombatObjectInformation
    {
        public float attackDelay;
    }
}
public partial class PlayerData // Data Field
{
    private Dictionary<string, PlayerInformation> playerInfoDict;
}

public partial class PlayerData // Initialize
{
    private void Allocate()
    {
        playerInfoDict = new Dictionary<string, PlayerInformation>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        MainSystem.Instance.DataManager.SetupData<PlayerInformation>(playerInfoDict, "PlayerData");
    }
}
public partial class PlayerData // Property
{
    public PlayerInformation GetData(string index)
    {
        return playerInfoDict[index];
    }
}