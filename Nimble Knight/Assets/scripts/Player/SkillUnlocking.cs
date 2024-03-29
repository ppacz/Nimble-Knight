using System.Collections.Generic;
using UnityEngine;

class SkillUnlocking : MonoBehaviour
{
    /// <summary>
    /// <String nameOfSKill, bool isUnlocked>
    /// </summary>
    [SerializeField]
    private Dictionary<string, bool> _skills = new Dictionary<string, bool>();
    [SerializeField]
    private Dictionary<string, int> _skillLevel = new Dictionary<string, int>();
    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null) 
        {
            _skillLevel = data.skillLevel;
            _skills = data.skills;
        }
        
    }
    /// <summary>
    /// adding skills into skill dictionary that keeps info about name and state of unlocking the skill
    /// </summary>
    /// <param name="skill"> name of skill </param>
    public void setSkills(string skill)
    {
        if (!_skills.ContainsKey(skill)) 
        {
            _skills.Add(skill, false);
            _skillLevel.Add(skill, 0);
        }
        
    }

    /// <summary>
    /// unlocks skill
    /// </summary>
    /// <param name="skill"> name of skill </param>
    public void unlockSkill(string skill)
    {
        Debug.Log("unlockSkill is called");
        _skills[skill] = true;
        _skillLevel[skill] += 1;
        PlayerManager.instance.player.GetComponent<PlayerControler>().newUpgrade(skill);
    }

    /// <returns>State of desired skill</returns>
    public bool getState(string skill)
    {
        return _skills[skill];
    }
    public int getSkillLevel(string skill)
    {
        return _skillLevel[skill];
    }


    /// <summary>
    /// Saving states of skill 
    /// </summary>
    /// <returns>dictionary that is than saved in SaveSystem</returns>
    public Dictionary<string,bool> getSkills()
    {
        return _skills;
    }

    public Dictionary<string, int> getSkillLevels()
    {
        return _skillLevel;
    }


    public bool isSkill(string skill)
    {
        return _skills.ContainsKey(skill);
    }
    /// <summary>
    /// info about skill
    /// </summary>
    /// <param name="skill"></param>
    /// <returns>if skill is already in the dict.</returns>
}
