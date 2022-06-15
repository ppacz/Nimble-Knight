using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip levelup;
    [SerializeField] private AudioClip abilityUpgrade;
    [SerializeField] private AudioClip potionConsume;
    [SerializeField] private AudioClip walk;
    [SerializeField] private AudioClip dash;
    [SerializeField] private float volume;
    private AudioSource[] source = new AudioSource[6];

    private void Start()
    {
        source = gameObject.GetComponents<AudioSource>();
        Debug.Log(source.Length);
    }
    public void playAttack()
    {
        if (source[0].isPlaying) return;
        source[0].volume = volume;
        source[0].PlayOneShot(attack);
    }

    public void playLevelUp()
    {
        if (source[1].isPlaying) return;
        source[1].volume = volume;
        source[1].PlayOneShot(levelup);
    }

    public void playAbilityUpgrade()
    {
        if (source[2].isPlaying) return;
        source[2].volume = volume;
        source[2].PlayOneShot(abilityUpgrade);
    }

    public void playPotionConsume()
    {
        if (source[3].isPlaying) return;
        source[3].volume = volume;
        source[3].PlayOneShot(potionConsume);
    }
    
    public void playWalk()
    {
        if (source[4].isPlaying) return;
        source[4].volume = volume/2;
        source[4].PlayOneShot(walk);
    }
    public void playDash()
    {
        if (source[5].isPlaying) return;
        source[5].volume = volume;
        source[5].PlayOneShot(dash);
    }

}
