using System;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public int topScore;
    public string topName;
    public string playerName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [Serializable]
    class SaveData
    {
        public int topScore;
        public string topName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.topName = topName;
        data.topScore = topScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topScore = data.topScore;
            topName = data.topName;
        }
        else
        {
            topScore = 0;
            topName = "None";
        }
    }

}
