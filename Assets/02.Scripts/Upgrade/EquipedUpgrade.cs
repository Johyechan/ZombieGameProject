using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedUpgrade : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerAttack playerAttack;

    public bool upgrade01 = false;
    public bool upgrade02 = false;
    public bool upgrade03 = false;
    public bool upgrade04 = false;
    public bool upgrade05 = false;
    public bool upgrade06 = false;
    public bool upgrade07 = false;
    public bool upgrade08 = false;
    public bool upgrade09 = false;
    public bool upgrade10 = false;
    public bool upgrade11 = false;
    public bool upgrade12 = false;
    public bool upgrade13 = false;
    public bool upgrade14 = false;

    public bool upgraded01 = false;
    public bool upgraded02 = false;
    public bool upgraded03 = false;
    public bool upgraded04 = false;
    public bool upgraded05 = false;
    public bool upgraded06 = false;
    public bool upgraded07 = false;
    public bool upgraded08 = false;
    public bool upgraded09 = false;
    public bool upgraded10 = false;
    public bool upgraded11 = false;
    public bool upgraded12 = false;
    public bool upgraded13 = false;
    public bool upgraded14 = false;

    public float hpPercent;

    private void FixedUpdate()
    {
        if (upgrade01 == true)
        {
            if(playerController.currentHp <= 30)
            {
                playerAttack.isupgradedDamage = true;
                upgraded01 = true;
            }
            else if (playerController.currentHp > 30)
            {
                playerAttack.isupgradedDamage = false;
            }
        }     

        if (upgrade02 == true)
        {
            playerAttack.BulletDamage += 5f;
            upgrade02 = false;
            upgraded02 = true;
        }

        if(upgrade03 == true)
        {
            playerAttack.cooltime -= 0.025f;
            upgrade03 = false;
            upgraded03 = true;
        }

        if(upgrade07 == true)
        {
            playerController.speed += 0.35f;
            upgrade07 = false;
            upgraded07 = true;
        }

        if(upgrade08 == true)
        {
            playerAttack.reloadtime -= 0.1f;
            upgrade08 = false;
            upgraded08 = true;
        }

        if(upgrade09 == true)
        {
            playerController.maxHp += 5f;
            upgrade09 = false;
            upgraded09 = true;
        }
    }
}
