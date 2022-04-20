using System.Collections.Generic;
using UnityEngine;

class SkillUnlocking : MonoBehaviour
{   
    [SerializeField]
    private Dictionary<string, bool> _skills = new Dictionary<string, bool>();
    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        _skills = data.skills;
    }
    public void setSkills(string skill)
    {   
        if(!_skills.ContainsKey(skill))_skills.Add(skill,false);
        
    }

    public void unlockSkill(string skill)
    {
        _skills[skill] = true;

    }

    public bool getState(string skill)
    {
        return _skills[skill];
    }
    
    public Dictionary<string,bool> getSkills()
    {
        return _skills;
    }
    
    public bool isSkill(string skill)
    {
        return _skills.ContainsKey(skill);
    }
}
