using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int level = 1; //레벨
    [SerializeField] int experience = 0; //경험치
    [SerializeField] ExperienceBar exBar;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 500;
        }
    }

    private void Start()
    {
        exBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        exBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        exBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            exBar.SetLevelText(level);
        }
    }
}
