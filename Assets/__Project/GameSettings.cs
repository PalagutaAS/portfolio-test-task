using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Game/Settings")]

public class GameSettings : ScriptableObject
{
    [SerializeField] private LevelProperties[] _properties;

    public int GetCountLevels { get => _properties.Length; }
    public LevelProperties GetLevelData(int level) => _properties?[level - 1];
    
}