public class LevelCounter
{
    private int _currentLevel = 1;
    private readonly int _maxLevel;

    public int CurrentLevel { get => _currentLevel; }
    public bool IsLastLevel { get => _maxLevel == _currentLevel; }
    public LevelCounter(GameSettings settings) 
    {
        _maxLevel = settings.GetCountLevels;
    }

    public void GoToNextLevel() => _currentLevel++;
    
    public void Restart() => _currentLevel = 1;
   
}
