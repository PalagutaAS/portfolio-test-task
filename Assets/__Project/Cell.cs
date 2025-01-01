using DG.Tweening;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer innerSprite;
    [SerializeField] private float size = 1;
    //[SerializeField] private IAnswerTrakcer answerTrakcer;
    private bool isCorrect;
    private Sprite sprite;

    public float Size { get => size; }
    public Transform InnerSpriteTransform { get => innerSprite.transform; }

    public Cell Constructor(Sprite innerSprite, bool isCorrect)
    {
        this.isCorrect = isCorrect;
        this.innerSprite.sprite = innerSprite;
        return this;
    }

    private void AnimateWrongAnswer()
    {
        InnerSpriteTransform.DOShakePosition(0.5f, 0.2f);
    }
}
