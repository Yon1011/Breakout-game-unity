using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Serializable]
    public class SaveData
    {
        public string name;
        public int score;
    }
    public string PlayerName { get; private set; }
    public SaveData Data { get; private set; }
    public static GameController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        string text = null;
        try
        {
            text = File.ReadAllText(Application.persistentDataPath + "/savedData.json");
        }
        catch (Exception ex)
        {

        }
        if (text == null)
        {
            Data = new SaveData();
            Data.name = "";
            Data.score = 0;
        }
        else
        {
            Data = JsonUtility.FromJson<SaveData>(text);
        }
    }

    public void SetName(string name)
    {
        PlayerName = name;
    }

    public void SetHighestScore(int score)
    {
        if (score > Data.score)
        {
            Data.name = PlayerName;
            Data.score = score;
        }
        Save();
    }
    private void Save()
    {
        var text = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + "/savedData.json", text);
    }
}

