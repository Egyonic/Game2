using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public void PlayGame()
    {
        //切换到游戏场景
        //SceneManager.LoadScene("SeaWorld");
        SceneManager.LoadScene("Game");
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            //Debug.Log(progressText.text);
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
