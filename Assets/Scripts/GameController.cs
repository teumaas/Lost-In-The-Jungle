using UnityEngine.SceneManagement;
using Assets.Scripts.Serializer.Post;
public static class GameController
{
    private static Level levelData;    

    public static void loadRuins(Level level) {
        levelData = level;
        SceneManager.LoadScene(1);
    }

    public static void loadVillage(Level level) {
        levelData = level;
        SceneManager.LoadScene(2);
    }

    public static void loadForestFire(Level level) {
        levelData = level;
        SceneManager.LoadScene(3);
    }

    public static Level getLevelData() {
        return levelData;
    }
}

