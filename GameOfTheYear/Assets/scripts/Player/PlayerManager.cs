using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton
    public static PlayerManager instance;
    public GameObject player;
    public GameObject center;
    public GameObject skillTree;
    
    private void Awake()
    {
        instance = this;
    }
    #endregion

    

}
