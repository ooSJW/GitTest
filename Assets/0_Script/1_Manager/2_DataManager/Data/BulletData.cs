using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class BulletData // Inner Class
{
    [System.Serializable]
    public class BulletInformation : BaseInformation
    {
        public string name;
        public float moveSpeed;
        public int damage;
    }
}
public partial class BulletData // Data Field
{
    private Dictionary<string, BulletInformation> bulletInfoDict;
}

public partial class BulletData // Initialize
{
    private void Allocate()
    {
        bulletInfoDict = new Dictionary<string, BulletInformation>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        MainSystem.Instance.DataManager.SetupData<BulletInformation>(bulletInfoDict, "BulletData");
    }
}
public partial class BulletData // Property
{
    public BulletInformation GetData(string index)
    {
        return bulletInfoDict[index];
    }
    public BulletInformation GetData(BulletName name)
    {
        return bulletInfoDict.Values.Where(elem => elem.name == name.ToString()).FirstOrDefault();
    }

}