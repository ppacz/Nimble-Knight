using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

        
    public void Quit()//quits game
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()//start asynch. loading of first level
    {
        StartCoroutine(LoadAsynch());
    }

    private IEnumerator LoadAsynch()//loads first level
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

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
