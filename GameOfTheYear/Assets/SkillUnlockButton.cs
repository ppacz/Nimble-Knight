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
        buttonText.text = "Unlock " + skillName;
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
        skillCost.text = "" + price;
    }
}
