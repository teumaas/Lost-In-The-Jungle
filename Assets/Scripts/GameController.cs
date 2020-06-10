using UnityEngine;

public static class GameController
{
    public static Level levelData;

    public static void LoadData(string data) {
        levelData = Level.CreateFromJSON(data);
        Debug.Log("LoadData called");
        Debug.Log(levelData);
    }
}

