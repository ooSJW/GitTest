using System.Collections.Generic;
using UnityEngine;
public partial class DataManager : MonoBehaviour // DataField
{
    public PlayerData PlayerData { get; private set; }
    public EnemyData EnemyData { get; private set; }
    public BulletData BulletData { get; private set; }
}
public partial class DataManager : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        PlayerData = new PlayerData();
        EnemyData = new EnemyData();
        BulletData = new BulletData();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
        PlayerData.Initialize();
        EnemyData.Initialize();
        BulletData.Initialize();
    }
    private void Setup()
    {

    }
}
public partial class DataManager : MonoBehaviour // Property
{
    private Wrapper<T> LoadJson<T>(string path) where T : BaseInformation
    {
        string json = Resources.Load<TextAsset>(path).ToString();
        return JsonUtility.FromJson<Wrapper<T>>(json);
    }
    public void SetupData<T>(Dictionary<string, T> dataDict, string path) where T : BaseInformation
    {
        dataDict.Clear();
        Wrapper<T> jsonData = LoadJson<T>(path);
        foreach (T elem in jsonData.array)
        {
            dataDict.Add(elem.index, elem);
        }
    }

    public int ScoreSaveLoad(int score = 0)
    {
        int highSocre = PlayerPrefs.GetInt(SaveDataName.HighestScore.ToString(), 0);
        if (highSocre < score)
        {
            highSocre = score;
            PlayerPrefs.SetInt(SaveDataName.HighestScore.ToString(), highSocre);
            PlayerPrefs.Save();
        }
        return highSocre;
    }
    public void SaveVolume(SaveDataName key)
    {
        // OnOff밖에 없으니 설정 시 값을 반전시킴.
        int result = LoadVolume(key) ? 0 : 1;
        PlayerPrefs.SetInt(key.ToString(), result);
        PlayerPrefs.Save();
    }

    public bool LoadVolume(SaveDataName key)
    {
        return PlayerPrefs.GetInt(key.ToString(), 1) == 0 ? false : true;
    }
}