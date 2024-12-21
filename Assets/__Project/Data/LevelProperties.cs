using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Game/LevelConfig")]
public class LevelProperties : ScriptableObject
{
    public int row;
    public int column;
}
