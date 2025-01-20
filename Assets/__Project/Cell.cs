using DG.Tweening;
using UnityEngine;
public interface IClickable
{
    void OnClick();
}

public class Cell : MonoBehaviour, IClickable
{
    [SerializeField] private SpriteRenderer innerSprite;
    [SerializeField] private float size = 1;
    private bool isCorrect;

    public float Size { get => size; }
    public Transform InnerSpriteTransform { get => innerSprite.transform; }

    public Cell Constructor(Sprite innerSprite, bool isCorrect)
    {
        this.isCorrect = isCorrect;
        this.innerSprite.sprite = innerSprite;
        return this;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER!");
        } else
        {
            AnimateWrongAnswer();
        }
    }

    private void AnimateWrongAnswer()
    {
        InnerSpriteTransform.DOShakePosition(0.4f, 0.19f);
    }

}
