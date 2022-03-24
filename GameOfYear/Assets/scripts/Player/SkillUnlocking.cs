using System.Collections.Generic;
using UnityEngine;

class SkillUnlocking : MonoBehaviour
{
    private Dictionary<string, bool> Skills = new Dictionary<string, bool>();

    public void Start()
    {
        Skills.Add("dash", false);
        Skills.Add("fireball", false);
    }

    public void unlockSkill(string name)
    {
        Skills[name] = true;

    }

    public bool getState(string name)
    {
        return Skills[name];
    }
}
