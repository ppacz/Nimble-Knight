using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip attack; 

    public void playAttackSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(attack);
    }
}
