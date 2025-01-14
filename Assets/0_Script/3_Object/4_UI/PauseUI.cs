using Unity.VisualScripting;
using UnityEngine;

public partial class PauseUI : MonoBehaviour // DataField
{

}
public partial class PauseUI : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        gameObject.SetActive(false);
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
public partial class PauseUI : MonoBehaviour // Property
{
    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}