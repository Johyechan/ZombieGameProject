using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] PauseManager pauseManager;

    private void Start()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }
}
