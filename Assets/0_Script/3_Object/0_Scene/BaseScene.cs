using System.Collections.Generic;
using UnityEngine;

public partial class BaseScene : MonoBehaviour // DataField
{
    [Header("Inheritance Member")]
    public List<GameObject> poolableObjectList = new List<GameObject>();
    [field: SerializeField] public SoundController SoundController { get; private set; }
}
public partial class BaseScene : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public virtual void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class BaseScene : MonoBehaviour // Main
{
    private void Awake()
    {
        MainSystem.Instance.SceneManager.SignupActiveScene(this);
    }
}