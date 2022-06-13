using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip levelup;
    [SerializeField] private AudioClip abilityUpgrade;
    [SerializeField] private AudioClip potionConsume;
    [SerializeField] private AudioClip walk;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void playAttack()
    {
        source.volume = 1;
        source.PlayOneShot(attack);
    }

    public void playLevelUp()
    {
        source.volume = 1;
        source.PlayOneShot(levelup);
    }

    public void playAbilityUpgrade()
    {
        source.volume = 1;
        source.PlayOneShot(abilityUpgrade);
    }

    public void playPotionConsume()
    {
        source.volume = 1;
        source.PlayOneShot(potionConsume);
    }
    
    public void playWalk()
    {
        source.volume = 1;
        source.PlayOneShot(walk);
    }

}
