using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerXP : MonoBehaviour
{
    [Header("XP stuff")]
    [SerializeField]
    private float _currentXP = 0;
    [SerializeField]
    private float _xpToNextLevel = 10;
    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private float _xpMultiplier = 2;
    [SerializeField]
    private int _skillPoints = 0;

    [Header("Text fields")]
    [SerializeField]
    private TMP_Text _levelText;
    [SerializeField]
    private TMP_Text _unusedPoints;
    [SerializeField]
    private Slider _xpBar;
    /// <summary>
    /// loads from save file if it exists
    /// </summary>
    private void Start()
    {
        PlayerData player = SaveSystem.LoadPlayer();
        if (player != null)
        {
            _currentXP = player.currentXP;
            _xpToNextLevel = player.xpToNextLevel;
            _level = player.level;
            _xpMultiplier = player.xpMulti;
            _skillPoints = player.skillPoints;
        }
        updateUI();
        if (_level != 1)
        {
            GameObject controls = GameObject.Find("controls");
            controls.SetActive(false);
        }
    }
    /// <summary>
    /// adds exp after enemy is killed and if threshold is reached it will level up and work with exp as intended
    /// </summary>
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
            gameObject.GetComponent<PlayerSoundManager>().playLevelUp();
            
        }
        updateUI();
    }
    
    /// <summary>
    /// Updates UI
    /// </summary>
    private void updateUI()
    {
        _xpBar.minValue = 0;
        _xpBar.maxValue = _xpToNextLevel;
        _xpBar.value = _currentXP;
        _levelText.text = "Level: " + _level;
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
    /// <summary>
    /// Unlocking skill
    /// </summary>
    /// <param name="price"></param>
    /// <returns>true if was used else false</returns>

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
    
    public float currentXP()
    {
        return _currentXP;
    }
    public float xpToNextLevel()
    {
        return _xpToNextLevel;
    }
    public int level()
    {
        return _level;
    }
    public float xpMultiplier()
    {
        return _xpMultiplier;
    }
    public int skillPoints()
    {
        return _skillPoints;
    }

}
