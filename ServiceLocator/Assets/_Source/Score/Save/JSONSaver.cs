using System.IO;
using UnityEngine;
using Zenject;

public class JSONSaver : ISaver
{
    private readonly Score _score;

    [Inject]
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
