using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class LoadingScene : BaseScene // DataField
{
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI loadingText;

    private float fadeSpeed;
    private float alpha;
    private bool fadeIn;
}
public partial class LoadingScene : BaseScene // Initialize
{
    private void Allocate()
    {

    }
    public override void Initialize()
    {
        base.Initialize();

        Allocate();
        Setup();
    }
    private void Setup()
    {
        fadeSpeed = 1f;
        alpha = 0.3f;
        fadeIn = true;
    }
}
public partial class LoadingScene : BaseScene // Main
{
    private void Start()
    {
        fillImage.fillAmount = 0;

        StartCoroutine(LoadSceneProces());
    }
    private void Update()
    {
        if (fadeIn)
        {
            alpha += fadeSpeed * Time.deltaTime;
            if (alpha >= 1f)
            {
                alpha = 1f;
                fadeIn = false;
            }
            else
                alpha -= fadeSpeed * Time.deltaTime;
            if (alpha <= 0.3f)
            {
                alpha = 0.3f;
                fadeIn = true;
            }
        }
        Color color = loadingText.color;
        color.a = alpha;
        loadingText.color = color;
    }
}
public partial class LoadingScene : BaseScene // Coroutine
{
    IEnumerator LoadSceneProces()
    {
        SceneName sceneName = MainSystem.Instance.SceneManager.SceneName;
        AsyncOperation loadScene = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName.ToString());
        loadScene.allowSceneActivation = false;
        float timer = 0;
        /*while (!loadScene.isDone)
        {
            if (loadScene.progress < 0.8f)
                fillImage.fillAmount = loadScene.progress;
            else
            {
                timer += Time.unscaledDeltaTime * 0.1f;
                fillImage.fillAmount = Mathf.Lerp(0.8f, 1f, timer);
                if (fillImage.fillAmount >= 1f)
                {
                    loadScene.allowSceneActivation = true;
                    yield break;
                }
            }

        }
        */
        while (loadScene.progress < 0.7f)
        {
            fillImage.fillAmount = loadScene.progress;
            yield return null;
        }
        while (fillImage.fillAmount < 1f)
        {
            timer += Time.unscaledDeltaTime * 0.8f;
            fillImage.fillAmount = Mathf.Lerp(0.7f, 1, timer);
            yield return null;
        }
        loadScene.allowSceneActivation = true;
    }
}