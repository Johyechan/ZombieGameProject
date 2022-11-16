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
    [SerializeField] UpgradeMenu upgradeMenu;

    public int levelToExperience = 700;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] public List<UpgradeData> acquiredUpgrades;
    [SerializeField] public List<UpgradeData> passiveUpgrades;

    [SerializeField]
    private EquipedUpgradeSO _euSO;
    int TO_LEVEL_UP
    {
        get
        {
            return level * levelToExperience;
        }
    }

    private void Start()
    {
        upgrades.Sort((a, b) => a.UpgradeCode.CompareTo(b.UpgradeCode));
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
                upgrades.Add(passiveUpgrades[0]);
                _euSO.upgrade02 = true;
            }
            if (item.UpgradeCode == 3 && _euSO.upgraded03 == false)
            {
                upgrades.Add(passiveUpgrades[9]);
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
                upgrades.Add(passiveUpgrades[13]);
                _euSO.upgrade07 = true;
            }
            if (item.UpgradeCode == 8 && _euSO.upgraded08 == false)
            {
                upgrades.Add(passiveUpgrades[17]);
                _euSO.upgrade08 = true;
            }
            if (item.UpgradeCode == 9 && _euSO.upgraded09 == false)
            {
                _euSO.upgrade09 = true;
                upgrades.Add(passiveUpgrades[25]);

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
            if (item.UpgradeCode == 14 && _euSO.upgraded14 == false)
            {
                _euSO.upgrade14 = true;
            }
            if (item.UpgradeCode == 15 && _euSO.upgraded15 == false)
            {
                _euSO.upgrade15 = true;
                upgrades.Add(passiveUpgrades[1]);
            }
            if (item.UpgradeCode == 16 && _euSO.upgraded16 == false)
            {
                _euSO.upgrade16 = true;
                upgrades.Add(passiveUpgrades[2]);
            }
            if (item.UpgradeCode == 17 && _euSO.upgraded17 == false)
            {
                _euSO.upgrade17 = true;
                upgrades.Add(passiveUpgrades[3]);
            }
            if (item.UpgradeCode == 18 && _euSO.upgraded18 == false)
            {
                _euSO.upgrade18 = true;
                upgrades.Add(passiveUpgrades[4]);
            }
            if (item.UpgradeCode == 19 && _euSO.upgraded19 == false)
            {
                _euSO.upgrade19 = true;
                upgrades.Add(passiveUpgrades[5]);
            }
            if (item.UpgradeCode == 20 && _euSO.upgraded20 == false)
            {
                _euSO.upgrade20 = true;
                upgrades.Add(passiveUpgrades[6]);
            }
            if (item.UpgradeCode == 21 && _euSO.upgraded21 == false)
            {
                _euSO.upgrade21 = true;
                upgrades.Add(passiveUpgrades[7]);
            }
            if (item.UpgradeCode == 22 && _euSO.upgraded22 == false)
            {
                _euSO.upgrade22 = true;
                upgrades.Add(passiveUpgrades[8]);
            }
            if (item.UpgradeCode == 23 && _euSO.upgraded23 == false)
            {
                _euSO.upgrade23 = true;
            }
            if (item.UpgradeCode == 24 && _euSO.upgraded24 == false)
            {
                _euSO.upgrade24 = true;
                upgrades.Add(passiveUpgrades[10]);
            }
            if (item.UpgradeCode == 25 && _euSO.upgraded25 == false)
            {
                _euSO.upgrade25 = true;
                upgrades.Add(passiveUpgrades[11]);
            }
            if (item.UpgradeCode == 26 && _euSO.upgraded26 == false)
            {
                _euSO.upgrade26 = true;
                upgrades.Add(passiveUpgrades[12]);
            }
            if (item.UpgradeCode == 27 && _euSO.upgraded27 == false)
            {
                _euSO.upgrade27 = true;
            }
            if (item.UpgradeCode == 28 && _euSO.upgraded28 == false)
            {
                _euSO.upgrade28 = true;
                upgrades.Add(passiveUpgrades[14]);
            }
            if (item.UpgradeCode == 29 && _euSO.upgraded29 == false)
            {
                _euSO.upgrade29 = true;
                upgrades.Add(passiveUpgrades[15]);
            }
            if (item.UpgradeCode == 30 && _euSO.upgraded30 == false)
            {
                _euSO.upgrade30 = true;
                upgrades.Add(passiveUpgrades[16]);
            }
            if (item.UpgradeCode == 31 && _euSO.upgraded31 == false)
            {
                _euSO.upgrade31 = true;
            }
            if (item.UpgradeCode == 32 && _euSO.upgraded32 == false)
            {
                _euSO.upgrade32 = true;
                upgrades.Add(passiveUpgrades[18]);
            }
            if (item.UpgradeCode == 33 && _euSO.upgraded33 == false)
            {
                _euSO.upgrade33 = true;
                upgrades.Add(passiveUpgrades[19]);
            }
            if (item.UpgradeCode == 34 && _euSO.upgraded34 == false)
            {
                _euSO.upgrade34 = true;
                upgrades.Add(passiveUpgrades[20]);
            }
            if (item.UpgradeCode == 35 && _euSO.upgraded35 == false)
            {
                _euSO.upgrade35 = true;
            }
            if (item.UpgradeCode == 36 && _euSO.upgraded36 == false)
            {
                _euSO.upgrade36 = true;
                upgrades.Add(passiveUpgrades[21]);
            }
            if (item.UpgradeCode == 37 && _euSO.upgraded37 == false)
            {
                _euSO.upgrade37 = true;
                upgrades.Add(passiveUpgrades[22]);
            }
            if (item.UpgradeCode == 38 && _euSO.upgraded38 == false)
            {
                _euSO.upgrade38 = true;
                upgrades.Add(passiveUpgrades[23]);
            }
            if (item.UpgradeCode == 39 && _euSO.upgraded39 == false)
            {  
                _euSO.upgrade39 = true;
                upgrades.Add(passiveUpgrades[24]);
            }
            if (item.UpgradeCode == 40 && _euSO.upgraded40 == false)
            {
                _euSO.upgrade40 = true;
            }
            if (item.UpgradeCode == 41 && _euSO.upgraded41 == false)
            {
                _euSO.upgrade41 = true;
                upgrades.Add(passiveUpgrades[26]);
            }
            if (item.UpgradeCode == 42 && _euSO.upgraded42 == false)
            {
                _euSO.upgrade42 = true;
                upgrades.Add(passiveUpgrades[27]);
            }
            if (item.UpgradeCode == 43 && _euSO.upgraded43 == false)
            {
                _euSO.upgrade43 = true;
                upgrades.Add(passiveUpgrades[28]);
            }
            if (item.UpgradeCode == 44 && _euSO.upgraded44 == false)
            {
                _euSO.upgrade44 = true;
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
        upgradeMenu.OpenIcon(selectedUpgrades[selectedUpgradeId]);
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
