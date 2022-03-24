using System.Collections.Generic;
using UnityEngine;

class SkillUnlocking : MonoBehaviour
{   
    [SerializeField]
    private Dictionary<string, bool> _skills = new Dictionary<string, bool>();

    public void setSkills(string skill)
    {
        _skills.Add(skill,false);
    }

    public void unlockSkill(string skill)
    {
        _skills[skill] = true;

    }

    public bool getState(string skill)
    {
        return _skills[skill];
    }
    
}
