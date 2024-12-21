using UnityEngine;

[System.Serializable]
public class LevelsConfig
{
    [SerializeField] private LevelProperties levelProperties;
    [SerializeField] private SpriteProperties spriteData;

    public LevelProperties Properties { get => levelProperties; }
    public SpriteProperties SpriteData { get => spriteData; }
}