using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioOnClick : MonoBehaviour
{
    [SerializeField] private AudioSource soundPlayer;
    public void playSoundEffect()
    {
        soundPlayer.Play();
    }
}
