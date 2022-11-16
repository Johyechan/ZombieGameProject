using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;   

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] PauseManager pauseManager;

    [SerializeField] Level level;
    [SerializeField] List<Image> images;

    private void Update()
    {
        //OpenIcon();
    }

    public void OpenIcon(UpgradeData upgradeData)
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].sprite.name == "Button07")
            {
                if (upgradeData.upgradeType != UpgradeType.PassiveLevelUp)
                {
                    images[i].sprite = upgradeData.icon;
                    break;
                }
            }         
        }
    }
}

