using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUnlockButton : MonoBehaviour
{
    private SkillUnlocking skillsSet;
    [SerializeField]
    private string skillName;
    [SerializeField]
    private int price;

    private void Start()
    {
        skillsSet = PlayerManager.instance.player.GetComponent<SkillUnlocking>();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            Button button = gameObject.GetComponent<Button>();
            UnlockSkillCommand(skillName, price);
            button.interactable = false;
        });
    }
    //dodìlat button stuff... ui update... skill unlocking atd..
    public void UnlockSkillCommand(string skillName, int price)
    {
        if (!skillsSet.getState(skillName))
        {
            if (gameObject.GetComponent<PlayerXP>().useSkillPoint(price)) skillsSet.unlockSkill(skillName);
            else Debug.Log("Není možné skill odemknout");
            return;

        }
        else
        {
            Debug.Log("Skill je jiz zakoupen");
            return;
        }
    }
}
