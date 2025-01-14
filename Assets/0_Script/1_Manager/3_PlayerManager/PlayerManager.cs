using UnityEngine;

public partial class PlayerManager : MonoBehaviour // DataField
{
    public Player Player { get; private set; } = default;
}
public partial class PlayerManager : MonoBehaviour // Initialize
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
public partial class PlayerManager : MonoBehaviour // Sign
{
    public void SignupPlayer(Player playerValue)
    {
        Player = playerValue;
        Player.Initialize();
    }
    public void SigndownPlayer()
    {
        Player = null;
    }
    public void PlayerDead(int lastScore = 0)
    {
        MainSystem.Instance.DataManager.ScoreSaveLoad(lastScore);
        StartCoroutine(MainSystem.Instance.UIManager.PlayerDeath());
    }
}