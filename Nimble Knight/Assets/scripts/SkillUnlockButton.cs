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
    private int maxAmount;
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
        Button button = gameObject.GetComponent<Button>();
        PlayerData data;
        data = SaveSystem.LoadPlayer();
        if (null!=data)
        {
            amount = data.skillLevel[skillName];
        }
        else amount = 0;
        if (isGrowing) { 
            for(int i=0;i< amount; i++)
            {
                price++;
            }
        }

        skillsSet = PlayerManager.instance.player.GetComponent<SkillUnlocking>();
        if (amount >= maxAmount)
        {
            button.interactable = false;
            buttonText.text = skillName + " already unlocked";
        }
        else
        {
            button.interactable = true;
            buttonText.text = "unlock " + skillName;
        }
        updateText();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {   
            

            if (UnlockSkillCommand(skillName, price))
            {
                if (isGrowing)
                {
                    price++;
                }
                amount++;
            }
            if (amount >= maxAmount)
            {
                button.interactable = false;
                buttonText.text = skillName + " already unlocked";
            }
            else
            {
                button.interactable = true;
                buttonText.text = "unlock " + skillName;
            }


            updateText();
        });
        //Debug.Log(skillsSet.isSkill(skillName) + ":" + skillsSet.getState(skillName));
        ///<summary>
        ///decides what should be inserted into the text below button
        ///</summary>
        
       
    }
    /// <summary>
    /// Takes care of buying upgrade 
    /// Returns true if skill can be purchased and false if it cannot.
    /// </summary>
    public bool UnlockSkillCommand(string skillName, int price)
    {
        if (PlayerManager.instance.player.GetComponent<PlayerXP>().useSkillPoint(price)) 
            {
                skillsSet.unlockSkill(skillName);
                return true;
            }
        GameObject.Find("popUpText").GetComponent<popUp>().textPop("Not enough skill points");
        Debug.Log("Není možné skill odemknout");
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
