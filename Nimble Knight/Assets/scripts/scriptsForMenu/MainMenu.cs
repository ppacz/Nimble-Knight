using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;


    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
    public void playGame()
    {
        File.Delete(Application.persistentDataPath + "/save.goy");
        StartCoroutine(LoadAsynch());
        
       
    }
    public void PlayGame()
    {
        StartCoroutine(LoadAsynch());
    }
    /// <summary>
    /// Loads scene asynchronously and if there is any save, it 
    /// will load its save when start button is clicked in the main menu
    /// </summary>
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
