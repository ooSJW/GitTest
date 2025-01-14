using UnityEngine;

public partial class MainSystemStart : MonoBehaviour // DataField
{
    private void Awake()
    {
        MainSystem.Instance.MainSystemStart();
    }
}
