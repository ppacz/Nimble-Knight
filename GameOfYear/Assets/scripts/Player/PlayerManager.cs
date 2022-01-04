using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //creates instance of this script so objects in him can be reffered in prefabs
    #region singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    //player its self
    public GameObject player;
    //players center
    public GameObject center;

}
