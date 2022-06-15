using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int skillPoints;
    public int currentHealth;
    public int maxHealth;
    public int maxStamina;
    public int sceneIndex;
    public int dmg;
    public float currentStamina;
    public float currentXP;
    public float xpToNextLevel;
    public float xpMulti;
    public float[] position = new float[2];
    public Dictionary<string, bool> skills;
    public Dictionary<string, int> skillLevel;
    /// <summary>
    /// stuff that needs to be saved to be able and continue from last save
    /// </summary>
    /// <param name="player"></param>
    public PlayerData(GameObject player)
    {
        PlayerXP xp = player.GetComponent<PlayerXP>();
        PlayerHP hp = player.GetComponent<PlayerHP>();
        PlayerStamina stamina = player.GetComponent<PlayerStamina>();
        SkillUnlocking skill = player.GetComponent<SkillUnlocking>();
        level = xp.level();
        skillPoints = xp.skillPoints();
        currentHealth = hp.HP();
        maxHealth = hp.maxHealth;
        dmg = player.GetComponent<PlayerCombat>().dmg;
        maxStamina = stamina.maxStamina;
        currentStamina = stamina.getStamina();
        currentXP = xp.currentXP();
        xpToNextLevel = xp.xpToNextLevel();
        xpMulti = xp.xpMultiplier();
        skills = skill.getSkills();
        skillLevel = skill.getSkillLevels();
        sceneIndex = PlayerManager.instance.sceneIndex;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
