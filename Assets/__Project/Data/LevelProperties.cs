using UnityEngine;

[System.Serializable]
public class LevelProperties
{
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private SpritesData spriteData;

    public int Row { get => row; }
    public int Column { get => column; }
    public IconSprites[] IconSprites { get => spriteData.IconSprites; }
}
