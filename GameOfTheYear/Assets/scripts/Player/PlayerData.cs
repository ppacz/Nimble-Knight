using System.Collections;
using System.Collections.Generic;
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
    
    public PlayerData(GameObject player)
    {
        PlayerXP xp = player.GetComponent<PlayerXP>();
        PlayerHP hp = player.GetComponent<PlayerHP>();
    }
}
