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
            _currentXP = 0;
            _level += 1;
            _skillPoints += 1;
            _xpToNextLevel = (int) _xpToNextLevel * _xpMultiplier;
            _xpMultiplier += .2f;
            
        }
        updateUI();
    }
    //will be updating UI XP elements
    private void updateUI()
    {
        _xpBar.minValue = 0;
        _xpBar.maxValue = _xpToNextLevel;
        // bcs of UI need to be decresed not added
        _xpBar.value = _xpToNextLevel-_currentXP;
        _levelText.text = "Level: " + _level;
        _xpText.text = _currentXP + "/" + _xpToNextLevel;
    }
}
