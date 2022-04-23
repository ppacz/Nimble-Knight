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
    
    ///<summary>
    /// adding event listener onto a button to level up and decide to do after leveling up
    /// </summary>
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
        ///<summary>
        ///decides what should be inserted into the text below button
        ///</summary>
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
    /// <summary>
    /// Takes care of buying upgrade 
    /// Returns true if skill can be purchased and false if it cannot.
    /// </summary>
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
    /// <summary>
    /// updates UI 
    /// </summary>
    private void updateText()
    {
        if (gameObject.GetComponent<Button>().interactable) skillCost.text = "" + price;
        else skillCost.text = "x";
    }
    
}
