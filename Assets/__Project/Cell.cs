using UnityEngine;
using VContainer;

[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    [Inject]
    private readonly IAnswerTrakcer _answerTrakcer;

    [SerializeField] private SpriteRenderer _innerSprite;
    [SerializeField] private float _size = 1;

    private bool _isCorrect;
    private bool _isEnabledTap = true;

    public float Size { get => _size; }
    public Transform InnerSpriteTransform { get => _innerSprite.transform; }
    public bool IsCorrect { get => _isCorrect; }

    public Cell Constructor(Sprite innerSprite, bool isCorrect)
    {
        _isCorrect = isCorrect;
        _innerSprite.sprite = innerSprite;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.HSVToRGB(Random.value, 0.32f, 1f);
        return this;
    }
    public void OnMouseDown()
    {
        if (_isEnabledTap)
        {
            _answerTrakcer.TapToCell(this);
        }
    }

    public void DisabledTap()
    {
        _isEnabledTap = false;
    }
}
