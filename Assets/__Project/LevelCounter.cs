public class LevelCounter
{
    private int currentLevel = 1;
    private readonly int maxLevel;

    public LevelCounter(GameSettings settings) 
    {
        maxLevel = settings.GetCountLevels;
    }
    public int CurrentLevel { get => currentLevel; }
    public bool IsLastLevel { get => maxLevel == currentLevel; }

    public void GoToNextLevel() {
        currentLevel++;
    }
    public void Restart() {
        currentLevel = 1;
    }
}
