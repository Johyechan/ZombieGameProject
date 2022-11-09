using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int level = 1; //레벨
    [SerializeField] int experience = 0; //경험치
    [SerializeField] ExperienceBar exBar;
    [SerializeField] UpgradeManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

    [SerializeField]
    private EquipedUpgradeSO _euSO;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 600;
        }
    }

    private void Start()
    {
        exBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        exBar.SetLevelText(level);
    }

    public void CheckEquipedItems()
    {
        foreach (var item in acquiredUpgrades)
        {
            if (item.UpgradeCode == 1 && _euSO.upgraded01 == false)
            {
                _euSO.upgrade01 = true;
            }
            if (item.UpgradeCode == 2 && _euSO.upgraded02 == false)
            {
                _euSO.upgrade02 = true;
            }
            if (item.UpgradeCode == 3 && _euSO.upgraded03 == false)
            {
                _euSO.upgrade03 = true;
            }
            if (item.UpgradeCode == 4 && _euSO.upgraded04 == false)
            {
                _euSO.upgrade04 = true;
            }
            if (item.UpgradeCode == 5 && _euSO.upgraded05 == false)
            {
                _euSO.upgrade05 = true;
            }
            if (item.UpgradeCode == 6 && _euSO.upgraded06 == false)
            {
                _euSO.upgrade06 = true;
            }
            if (item.UpgradeCode == 7 && _euSO.upgraded07 == false)
            {
                _euSO.upgrade07 = true;
            }
            if (item.UpgradeCode == 8 && _euSO.upgraded08 == false)
            {
                _euSO.upgrade08 = true;
            }
            if (item.UpgradeCode == 9 && _euSO.upgraded09 == false)
            {
                _euSO.upgrade09 = true;
            }
            if (item.UpgradeCode == 10 && _euSO.upgraded10 == false)
            {
                _euSO.upgrade10 = true;
            }
            if (item.UpgradeCode == 11 && _euSO.upgraded11 == false)
            {
                _euSO.upgrade11 = true;
            }
            if (item.UpgradeCode == 12 && _euSO.upgraded12 == false)
            {
                _euSO.upgrade12 = true;
            }
            if (item.UpgradeCode == 13 && _euSO.upgraded13 == false)
            {
                _euSO.upgrade13 = true;
            }
        }
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        exBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    internal void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }
    
        acquiredUpgrades.Add(upgradeData);
        CheckEquipedItems();
        upgrades.Remove(upgradeData);
    }

    private void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }     
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        exBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {

        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[UnityEngine.Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
