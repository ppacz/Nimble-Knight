using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public TMP_Text staminaText;
    public int maxStamina;
    public Slider slider;
    private float currentStamina;
    void Start()
    {
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;
        slider.minValue = 0;
        staminaText.text = currentStamina + "/" + maxStamina;
        slider.value = currentStamina;
    }

    private void FixedUpdate()
    {
        if(currentStamina < maxStamina)
        {
            currentStamina += .2f;
            UpdateText();
        }
    }
    //Returns boolean bcs of condition that is in PlayerControler script that takes care of stamina usage
    public bool useAbility(float consumption)
    {
        if (currentStamina >= consumption)
        {   
            currentStamina -= consumption;
            UpdateText();
            return true;
        }else{
            Debug.Log("Not enough stamina");
            return false;
        }

    }

    //updates text
    private void UpdateText() 
    {
        slider.value = currentStamina;
        staminaText.text = (int)currentStamina + "/" + maxStamina;
    }
}
