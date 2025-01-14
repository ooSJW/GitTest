using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class LobbyUI : MonoBehaviour // DataField
{
    [SerializeField] private TextMeshProUGUI scoreText;
}
public partial class LobbyUI : MonoBehaviour // Initialize
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
        SetScoreText();
    }
}
public partial class LobbyUI : MonoBehaviour // property
{
    public void SetScoreText()
    {
        int score = PlayerPrefs.GetInt(SaveDataName.HighestScore.ToString(), 0);
        scoreText.text = $"최고 점수 : {score}";
    }
}