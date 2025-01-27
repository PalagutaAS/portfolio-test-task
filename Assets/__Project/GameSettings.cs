using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Game/Settings")]

public class GameSettings : ScriptableObject
{
    [SerializeField] private LevelProperties[] properties;

    public int GetCountLevels { get => properties.Length; }
    public LevelProperties GetLevelData(int level)
    {
        return properties?[level - 1];
    }
}