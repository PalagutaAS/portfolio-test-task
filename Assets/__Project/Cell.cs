using UnityEngine;
using VContainer;
public interface IClickable
{
    void OnClick();
}

[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    [Inject]
    private readonly IAnswerTrakcer _answerTrakcer;

    [SerializeField] private SpriteRenderer _innerSprite;
    [SerializeField] private float _size = 1;

    private bool _isCorrect;

    public float Size { get => _size; }
    public Transform InnerSpriteTransform { get => _innerSprite.transform; }
    public bool IsCorrect { get => _isCorrect; }

    public Cell Constructor(Sprite innerSprite, bool isCorrect)
    {
        this._isCorrect = isCorrect;
        this._innerSprite.sprite = innerSprite;
        return this;
    }

    public void OnMouseDown()
    {
        //
        _answerTrakcer.TapToCell(this);
    }

}
