using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUnlockButton : MonoBehaviour
{
    private SkillUnlocking skillsSet;
    [SerializeField]
    private string skillName;
    [SerializeField]
    private int price;
    [SerializeField]
    private bool isGrowing;
    [SerializeField]
    private int maxAmount=1;
    private int amount;
    [SerializeField]
    private TMP_Text buttonText;
    [SerializeField]
    private TMP_Text skillCost;
    

    private void Start()
    {
        amount = 0;
        
        skillsSet = PlayerManager.instance.player.GetComponent<SkillUnlocking>();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {   
            Button button = gameObject.GetComponent<Button>();
            if (amount == maxAmount - 1)
            {
                button.interactable = !UnlockSkillCommand(skillName, price);
                amount++;
            }
            else if (amount < maxAmount)
            {
                if (UnlockSkillCommand(skillName, price))
                {
                    if (isGrowing) price++;
                    amount++;

                }
            } else if (amount == maxAmount)button.interactable = false;
            updateText();
        });
        //Debug.Log(skillsSet.isSkill(skillName) + ":" + skillsSet.getState(skillName));
        if (skillsSet.isSkill(skillName))
        {
            gameObject.GetComponent<Button>().interactable = !skillsSet.getState(skillName);
            if (skillsSet.getState(skillName))
            {
                buttonText.text = skillName + " already unlocked";
            }
            else
            {
                buttonText.text = "unlock " + skillName;
            }
        
        }
        updateText();
    }
    //dodìlat button stuff... ui update... skill unlocking atd..
    public bool UnlockSkillCommand(string skillName, int price)
    {
        if (!skillsSet.getState(skillName))
        {
            if (PlayerManager.instance.player.GetComponent<PlayerXP>().useSkillPoint(price)) 
            {
                skillsSet.unlockSkill(skillName);
                return true;
            }
            else Debug.Log("Není možné skill odemknout");
        }
        return false;
    }
    
    private void updateText()
    {
        if (gameObject.GetComponent<Button>().interactable) skillCost.text = "" + price;
        else skillCost.text = "x";
    }
}
