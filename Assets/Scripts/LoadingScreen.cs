using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBarFill;


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        loadingScreen.SetActive(true);

        loadingBarFill.fillAmount += 0.05f;


        yield return new WaitForSecondsRealtime(3);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {

            float progressValue = Mathf.Clamp01((operation.progress / 0.9f) + 0.5f);

            loadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
