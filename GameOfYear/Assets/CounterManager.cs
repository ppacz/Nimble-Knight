using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    #region singleton
    public static CounterManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject counter;
}
