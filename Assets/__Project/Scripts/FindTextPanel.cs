using UnityEngine;
using UnityEngine.UI;

public class FindTextPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    
    public void SetNameFindObject(string nameFindObject)
    {
        nameFindObject = "Find " + nameFindObject;
        text.text = nameFindObject;
    }
}
