using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Game/Settings")]

public class GameSettings : ScriptableObject
{
    [SerializeField] private LevelProperties[] properties;

    public LevelProperties GetLevelData(int level)
    {
        return properties?[level - 1];
    }
}