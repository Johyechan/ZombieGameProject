using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EquipedUpgrade : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] Bullet bullet;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    [SerializeField] [Range(0f, 1f)] float stealHpChance = 1f;

    public EquipedUpgradeSO _euSO;

    private void Awake()
    {
        _euSO.OnAfterDeserialize();
    }

    public void StealHp()
    {
        if (_euSO.upgrade06)
        {
            if (Random.value < stealHpChance)
            {
                playerController.currentHp += 0.7f;
            }
        }
    }

    private IEnumerator CameraZoom()
    {
        for (int i = 0; i < 25; i++)
        {
            cinemachine.m_Lens.OrthographicSize += 0.06f;
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (_euSO.upgrade01 == true)
        {
            if(playerController.currentHp <= 30)
            {
                playerAttack.isupgradedDamage = true;
                _euSO.upgraded01 = true;
            }
            else if (playerController.currentHp > 30)
            {
                playerAttack.isupgradedDamage = false;
            }
        }     

        if (_euSO.upgrade02 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade02 = false;
            _euSO.upgraded02 = true;
        }

        if(_euSO.upgrade03 == true)
        {
            playerAttack.cooltime -= 0.025f;
            _euSO.upgrade03 = false;
            _euSO.upgraded03 = true;
        }

        if(_euSO.upgrade04 == true)
        {
            playerAttack.isPenetrated = true;
        }

        if(_euSO.upgrade05 == true)
        {

        }


        if(_euSO.upgrade07 == true)
        {
            playerController.speed += 0.35f;
            _euSO.upgrade07 = false;
            _euSO.upgraded07 = true;
        }

        if(_euSO.upgrade08 == true)
        {
            playerAttack.reloadtime -= 0.1f;
            _euSO.upgrade08 = false;
            _euSO.upgraded08 = true;
        }

        if(_euSO.upgrade09 == true)
        {
            playerController.maxHp += 5f;
            _euSO.upgrade09 = false;
            _euSO.upgraded09 = true;
        }


        if(_euSO.upgrade13 == true)
        {
            StartCoroutine(CameraZoom());
            _euSO.upgrade13 = false;
            _euSO.upgraded13 = true;
        }
    }
}
