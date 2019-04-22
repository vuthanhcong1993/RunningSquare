using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class BuySave
{
    public List<int> charactersBuyed = new List<int>();
    public int characterSelected = 0;
}

public class SaveManager : Singleton<SaveManager>
{

    public BuySave buySave = new BuySave();
    // string dbPath = "";
     private string gameSavePath = "Resources/a.txt";
  //  private string gameSavePath =  Application.persistentDataPath + "/BuySave.json";


    private void Awake()
    {

#if UNITY_EDITOR

        SetPath();   
#endif

    }
   

    public void Save()
    {
        string dataAsJson = JsonUtility.ToJson(buySave);
         string filePath =/* Application.dataPath +*/ gameSavePath;
        //  string filePath = Application.streamingAssetsPath + "/BuySave.json";
       // string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "BuySave.json");

            File.WriteAllText(filePath, dataAsJson);
       // TextAsset level = Resources.Load<TextAsset>("BuySave") ;
  
        //Debug.Log(level.text);

    }

   public void Load()  
    {
        string filePath = /*Application.dataPath +*/ gameSavePath;
       
        //string filePath = Application.streamingAssetsPath + "/BuySave.json";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            buySave = JsonUtility.FromJson<BuySave>(dataAsJson);
        }
       


    }
    // Read file from streamingPath on android 
    void SetPath()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "BuySave.json");
            // Android only use WWW to read file
            WWW reader = new WWW(oriPath);
            while (!reader.isDone) { }

           string realPath = Application.persistentDataPath + "/BuySave.json";
           File.WriteAllText(realPath, reader.text);

            gameSavePath = realPath;
        }
        else
        {
            // iOS
            gameSavePath = Path.Combine(Application.streamingAssetsPath, "BuySave.json");
        }
    }
}


