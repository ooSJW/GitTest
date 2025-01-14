using System.Collections;
using TMPro;
using UnityEngine;

public partial class Dialog : MonoBehaviour // DataField
{
    [SerializeField] private TextMeshProUGUI dialogText;
    private string currentDialog;
    private float typingSpeed = 0.05f;
}
public partial class Dialog : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        currentDialog = $"게임을 시작합니다.\n 현재 최고점수 : {MainSystem.Instance.DataManager.ScoreSaveLoad()}";
    }
    public void Initialize()
    {
        Allocate();
        Setup();
        StartCoroutine(TypingDialog());
    }
    private void Setup()
    {

    }
}
public partial class Dialog : MonoBehaviour // Coroutine
{
    IEnumerator TypingDialog()
    {
        dialogText.text = "";
        foreach (char letter in currentDialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
public partial class Dialog : MonoBehaviour // Property
{
    public void OffDialog()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}