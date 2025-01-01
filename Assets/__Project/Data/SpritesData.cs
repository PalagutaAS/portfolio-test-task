using UnityEngine;

[CreateAssetMenu(fileName = "New Sprite Data", menuName = "Game/SpriteData")]
public class SpritesData : ScriptableObject
{
    [SerializeField] private IconSprites[] iconSprites;

    public IconSprites[] IconSprites { get => iconSprites; }
}