using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton
    public static PlayerManager instance;
    public GameObject player;
    public GameObject center;
    
    private void Awake()
    {
        instance = this;
 
    }
    #endregion

    

}
