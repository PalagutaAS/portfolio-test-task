using UnityEngine;
using UnityEngine.UI;

public class FindTextPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    
    public void SetNameFindObject(string nameFindObject)
    {
        text.text = "Find " + nameFindObject;
    }
}
