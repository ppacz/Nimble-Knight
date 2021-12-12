using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int count = 5;


    public void Died()
    {
        count--;
        if (count == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
