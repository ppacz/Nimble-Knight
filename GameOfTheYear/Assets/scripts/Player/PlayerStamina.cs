using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public TMP_Text staminaText;
    public int maxStamina;
    public Slider slider;
    private float currentStamina;
    public float regen { get; set; }
    void Start()
    {
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;
        slider.minValue = 0;
        staminaText.text = currentStamina + "/" + maxStamina;
        slider.value = currentStamina;
        regen = 1;
        InvokeRepeating("AddStamina", 0f, 5f);
    }
    /// <summary>
    /// refueling stamina
    /// </summary>
    /// <summary>
    /// Decresing amount of mana/stamina
    /// </summary>
    /// <param name="consumption">By how much it should decrese</param>
    /// <returns>true if there was enough else false</returns>
    public bool useAbility(float consumption)
    {
        if (currentStamina >= consumption)
        {   
            currentStamina -= consumption;
            UpdateUI();
            return true;
        }else{
            Debug.Log("Not enough stamina");
            return false;
        }

    }

    /// <summary>
    /// updates UI
    /// </summary>
    private void UpdateUI() 
    {
        slider.value = currentStamina;
        staminaText.text = (int)currentStamina + "/" + maxStamina;
    }
    /// <summary>
    /// For potions
    /// </summary>
    /// <param name="stamina"></param>
    public void AddStamina(float stamina)
    {
        if (currentStamina + stamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else
        {
            currentStamina += stamina;
        }
        UpdateUI();
    }
    public void AddStamina()
    {
        if (currentStamina + regen >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else
        {
            currentStamina += regen;
        }
        UpdateUI();
    }
}
