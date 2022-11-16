using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllScene : LevelLoader
{
    public GameObject SettingPan;
   
    public GameObject OthersPan;

    
    public void GoMain()
    {
        LoadNextLevel();

    }
    public void SettingPanUp()
    {
        SettingPan.SetActive(true);
    }
    public void SettingPanDown()
    {
        SettingPan.SetActive(false);
    }
    public void OthersPanUp()
    {
        OthersPan.SetActive(true);
    }
    public void OthersPanDown()
    {
        OthersPan.SetActive(false);
    }
   
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SettingPan.active)
            { 
                SettingPan.SetActive(false); 
            }
            if(OthersPan.active)
            {
                OthersPan.SetActive(false);
            }
            
            
        }
    }


        }
