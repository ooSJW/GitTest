using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneManager : MonoBehaviour // DataField
{
    public BaseScene ActiveScene { get; private set; }
    public SceneName SceneName { get; private set; }
}
public partial class SceneManager : MonoBehaviour // Initialize
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
public partial class SceneManager : MonoBehaviour // Property
{
    public void LoadScene(SceneName sceneNameValue)
    {
        SceneName = sceneNameValue;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName.LoadingScene.ToString());
    }
}
public partial class SceneManager : MonoBehaviour // Sign
{
    public void SignupActiveScene(BaseScene activeSceneValue)
    {
        ActiveScene = activeSceneValue;
        ActiveScene.Initialize();
    }
    public void SigndownActiveScene()
    {
        ActiveScene = null;
    }
}