using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour // DataField
{
    public UIController UIController { get; private set; } = default;
}
public partial class UIManager : MonoBehaviour // Initialize
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
public partial class UIManager : MonoBehaviour // Property
{
    public IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(1.5f);
        GameOver();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        UIController.GameOver();
    }
}
public partial class UIManager : MonoBehaviour // sign
{
    public void SignupUIController(UIController uIControllerValue)
    {
        UIController = uIControllerValue;
        UIController.Initialize();
    }
    public void SigndownUIController()
    {
        UIController = null;
    }
}