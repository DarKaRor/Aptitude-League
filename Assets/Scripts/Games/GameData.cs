using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public enum GameType
{
    Time,
    Points,
    Lives
}

[System.Serializable]
public class GameData
{
    [SerializeField] public GameType type;
    public string name;
    public string description;
    public Dialogue[] viviHelp;
    public string sceneName;
    public string message;
    public string OSTName;
    int id;
    public int Id { get => id; }

    public GameData(GameType type, string name, string description, string sceneName, Dialogue[] viviHelp, string message = null, string OSTName = null)
    {
        this.type = type;
        this.name = name;
        this.description = description;
        this.viviHelp = viviHelp;
        this.sceneName = sceneName;
        this.OSTName = OSTName;
        this.message = message;

        List<GameData> gameDatas = GameManager.sharedInstance.gameDatas;
        int maxId = -1;
        if(gameDatas.Count > 0) maxId = gameDatas.Select(i => i.id).Max();
        
        id = maxId + 1;

        GameManager.sharedInstance.gameDatas.Add(this);
    }
}
