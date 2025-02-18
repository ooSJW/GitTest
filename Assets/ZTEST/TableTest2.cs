using UnityEngine;

public partial class TableTest2 : MonoBehaviour // DataField
{
    [SerializeField] private TableTest tableTest;
}
public partial class TableTest2 : MonoBehaviour // Initialize
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
public partial class TableTest2 : MonoBehaviour // 
{
    private void Start()
    {
        print("int : " + tableTest.intValue);
        print("float : " + tableTest.floatValue);
        print("string : " + tableTest.stringValue);
    }
}