using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject fadeImage;
    [SerializeField] float fadeDelay;
    public void ChangeGameScene(string scene)
    {
        StartCoroutine(FadeAndQuit(scene));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private IEnumerator FadeAndQuit(string scene)
    {
        fadeImage.SetActive(true);
        yield return new WaitForSeconds(fadeDelay);
        SceneManager.LoadScene(scene);
    }
}
