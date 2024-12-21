using UnityEngine;

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



internal interface IClickController
{
    void Clicked();
}