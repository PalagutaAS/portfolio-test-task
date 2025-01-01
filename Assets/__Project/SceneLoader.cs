using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image fadePanel;
    [SerializeField] private int sceneID;

    private AsyncOperation operation;

    private void Start()
    {
        StartCoroutine(LoadScene(sceneID));
    }

    IEnumerator LoadScene(int sceneID)
    {
        yield return new WaitForSeconds(1f);
        operation = SceneManager.LoadSceneAsync(sceneID);
        operation.allowSceneActivation = false;
        
        float timeLoad = 0;
        while (operation.progress < 0.9f || timeLoad < 2f)
        {
            //Debug.Log(operation.progress < 0.9f || timeLoad < 2f);
            timeLoad += Time.deltaTime;
            image.fillAmount = timeLoad / 2f;
            yield return null;
        }
        timeLoad = 0;
        Color fadeColor = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 1f);
        Color tempColor = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0f);
        while (timeLoad < 1f)
        {
            timeLoad += Time.deltaTime;
            fadePanel.color = Color.Lerp(tempColor, fadeColor, timeLoad / 1f);
            yield return null;
        }
        operation.allowSceneActivation = true;
    }

}
