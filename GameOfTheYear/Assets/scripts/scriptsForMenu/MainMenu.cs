using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;


    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadAsynch());
    }

    private IEnumerator LoadAsynch()
    {
        AsyncOperation operation;
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            operation = SceneManager.LoadSceneAsync(data.sceneIndex);
        }
        else
        { 
        operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        loadingScreen.SetActive(true);

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            progressText.text = progress*100 + "%";
            yield return null;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
