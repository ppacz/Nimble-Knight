using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerXP : MonoBehaviour
{
    [Header("XP settigns")]
    [SerializeField]
    private float _currentXP = 0;
    [SerializeField]
    private float _xpToNextLevel = 10;
    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private float _xpMultiplier = 2f;
    [SerializeField]
    private int _skillPoints { get; set; }

    [Header("Text fields")]
    [SerializeField]
    private TMP_Text _xpText;
    [SerializeField]
    private TMP_Text _levelText;
    [SerializeField]
    private TMP_Text _unusedPoints;
    [SerializeField]
    private Slider _xpBar;
    private void Start()
    {
        updateUI();
        _skillPoints = 0;
        
    }
    // will be called after enemy dies and will also check if player has enough Xp to level up
    public void addExp(int value)
    {
        _currentXP += value;
        if (_currentXP >= _xpToNextLevel) 
        {
            _currentXP -= _xpToNextLevel ;
            _level += 1;
            _skillPoints += 1;
            _xpToNextLevel = (int) (_xpToNextLevel * _xpMultiplier);
            _xpMultiplier += .2f;
            
        }
        updateUI();
    }
    //will be updating UI XP elements
    private void updateUI()
    {
        _xpBar.minValue = 0;
        _xpBar.maxValue = _xpToNextLevel;
        _xpBar.value = _currentXP;
        _levelText.text = "Level: " + _level;
        //pro vypis xp zbyvajic�
        _xpText.text = "xp: "+_currentXP + "/" + _xpToNextLevel;
        //pro vypis xp procentama
        //_xpText.text = "xp: "+ Math.Round((_currentXP*100/_xpToNextLevel),2)+"%";
        //takes care of showing if there are any unused scripts
        if (_skillPoints > 0)
        {
            _unusedPoints.text = "Unused points: " + _skillPoints;
        }
        else
        {
            _unusedPoints.text = "";
        }
    }

    public bool useSkillPoint(int price) 
    {
        if (price > _skillPoints)
        {
            Debug.Log("Nedostatek skill pointu!!");
            return false;
        }
        else
        {
            
            _skillPoints -= price;
            updateUI();
            return true;
        }
    }
}