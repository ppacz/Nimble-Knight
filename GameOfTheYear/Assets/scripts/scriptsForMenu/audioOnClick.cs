using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioOnClick : MonoBehaviour
{
    public AudioSource soundPlayer;

    void Start()
    { 
    }
    void Update()
    {   
    }

    public void playSoundEffect()
    {
        soundPlayer.Play();
    }
}
