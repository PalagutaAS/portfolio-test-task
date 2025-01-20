using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickController : MonoBehaviour
{
    private IClickable clickable;

    private void Awake()
    {
        clickable = GetComponent<IClickable>();
    }

    private void OnMouseDown()
    {
        clickable?.OnClick();
    }
}