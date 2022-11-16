using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject upgradePanel;
    [SerializeField] PauseManager pauseManager;

    private void Start()
    {
        panel.SetActive(false);
        upgradePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (upgradePanel.activeInHierarchy == false)
            {
                OpenMenu2();
            }
            else
            {
                CloseMenu2();
            }
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);      
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }

    public void CloseMenu2()
    {
        pauseManager.UnPauseGame();
        upgradePanel.SetActive(false);
    }

    public void OpenMenu2()
    {
        pauseManager.PauseGame();
        upgradePanel.SetActive(true);
    }
}
