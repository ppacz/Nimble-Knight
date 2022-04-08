using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int skillPoints;
    public int currentHealth;
    public int maxHealth;
    public float currentXP;
    public float xpToNextLevel;
    public float xpMulti;

    public PlayerData(GameObject player)
    {
        PlayerXP xp = player.GetComponent<PlayerXP>();
        PlayerHP hp = player.GetComponent<PlayerHP>();
        level = xp.level();
        skillPoints = xp.skillPoints();
        currentHealth = hp.HP();
        maxHealth = hp.maxHealth;
        currentXP = xp.currentXP();
        xpToNextLevel = xp.xpToNextLevel();
        xpMulti = xp.xpMultiplier();
    }
}
