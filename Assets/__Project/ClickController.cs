using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickController : MonoBehaviour, IClickController
{ 
    public void Clicked()
    {
        throw new System.NotImplementedException();
    }

    private void OnMouseDown()
    {
        Clicked();
    }
}

public interface IClickController
{
    void Clicked();
}