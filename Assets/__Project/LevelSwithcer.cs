public class LevelSwithcer 
{
    private int currentLevel = 1;

    public int CurrentLevel { get => currentLevel; private set => currentLevel = value; }

    public void GoToNextLevel() {
        CurrentLevel++;
    }
}
