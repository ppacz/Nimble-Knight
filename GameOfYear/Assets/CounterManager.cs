using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    //creates instance of this script so objects in him can be reffered in prefabs
    #region singleton
    public static CounterManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    //will be later removed and changed with different script (will be based in Spawner code propably)
    public GameObject counter;
}
