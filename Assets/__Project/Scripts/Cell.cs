using UnityEngine;
using VContainer;

[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    [Inject]
    private readonly IAnswerTrakcer _answerTrakcer;

    [SerializeField] private SpriteRenderer _innerSprite;

    private SpriteRenderer _sprite;
    private bool _isCorrect;
    private bool _isEnabledTap = true;
    
    public Transform InnerSpriteTransform { get => _innerSprite.transform; }
    public bool IsCorrect { get => _isCorrect; }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public Cell Constructor(Sprite innerSprite, bool isCorrect, float cellSize)
    {
        _isCorrect = isCorrect;
        _innerSprite.sprite = innerSprite;
        _sprite.color = Color.HSVToRGB(Random.value, 0.32f, 1f);
        transform.localScale = new Vector2(cellSize, cellSize);
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
