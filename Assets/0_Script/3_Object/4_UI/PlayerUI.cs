using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerUI : MonoBehaviour // DataField
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public int CurrentScore { get; private set; }
    private string highScorebasic;
    private string scorebasic;
}

public partial class PlayerUI : MonoBehaviour // Initialize
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
        highScorebasic = "최고 점수 : ";
        scorebasic = "현재 점수 : ";
        int highScore = MainSystem.Instance.DataManager.ScoreSaveLoad();
        highScoreText.text = highScorebasic + highScore.ToString();
        scoreText.text = scorebasic + 0.ToString();
    }
}
public partial class PlayerUI : MonoBehaviour // 
{
    public void SetScore(int scoreValue)
    {
        scoreText.text = scorebasic + scoreValue.ToString();
        if (scoreValue >= MainSystem.Instance.DataManager.ScoreSaveLoad(scoreValue))
            highScoreText.text = highScorebasic + scoreValue.ToString();

        CurrentScore = scoreValue;
    }
}