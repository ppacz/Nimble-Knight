using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsDeathScreen : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0); 
    }
    public void loadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(data.sceneIndex);
        }
    }
}
