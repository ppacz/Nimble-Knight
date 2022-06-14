using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip levelup;
    [SerializeField] private AudioClip abilityUpgrade;
    [SerializeField] private AudioClip potionConsume;
    [SerializeField] private AudioClip walk;
    [SerializeField] private float volume;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void playAttack()
    {
        source.volume = volume;
        source.PlayOneShot(attack);
    }

    public void playLevelUp()
    {
        source.volume = volume;
        source.PlayOneShot(levelup);
    }

    public void playAbilityUpgrade()
    {
        source.volume = volume;
        source.PlayOneShot(abilityUpgrade);
    }

    public void playPotionConsume()
    {
        source.volume = volume;
        source.PlayOneShot(potionConsume);
    }
    
    public void playWalk()
    {
        source.volume = volume/2;
        source.PlayOneShot(walk);
    }

}
