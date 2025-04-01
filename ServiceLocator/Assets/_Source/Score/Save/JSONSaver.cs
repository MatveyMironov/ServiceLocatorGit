using System.IO;
using UnityEngine;

public class JSONSaver : ISaver
{
    private readonly Score _score;

    public JSONSaver(Score score)
    {
        _score = score ?? throw new System.ArgumentNullException(nameof(score));
    }

    public void SaveScore(string path = null)
    {
        string json = JsonUtility.ToJson(_score);
        File.WriteAllText(path + "/saveFile.json", json);
        Debug.Log("Saved " + Application.persistentDataPath);
        Debug.Log(json);
    }
}
