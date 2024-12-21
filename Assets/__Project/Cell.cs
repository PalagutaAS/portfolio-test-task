using DG.Tweening;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer innerSprite;
    [SerializeField] private float size = 1;
    private bool isCorrect;
    private Sprite sprite;

    public float Size { get => size; }

    public Cell Initialize(Sprite innerSprite, string name, bool isCorrect)
    {
        this.isCorrect = isCorrect;
        this.innerSprite.sprite = innerSprite;
        this.name = name;
        Invoke(nameof(AnimateWrongAnswer), 1f);
        return this;
    }

    private void AnimateWrongAnswer()
    {
        innerSprite.transform.DOShakePosition(0.5f, 0.2f);
    }
}
