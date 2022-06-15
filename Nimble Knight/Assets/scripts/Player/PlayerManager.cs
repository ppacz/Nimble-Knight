using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// Player manager for using some variables as global for refferences and also some saves
    /// </summary>
    #region singleton
    public static PlayerManager instance;
    public GameObject player;
    public GameObject center;
    public GameObject skillTree;
    public int sceneIndex;
    
    private void Awake()
    {
        instance = this;
    }
    #endregion
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    

}
