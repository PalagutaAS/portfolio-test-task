using UnityEngine;

[System.Serializable]
public class IconSprites
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string name;

    public Sprite Sprite { get => sprite; }
    public string Name { get => name; }
}
