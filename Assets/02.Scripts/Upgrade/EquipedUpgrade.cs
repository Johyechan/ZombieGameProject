using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Experimental.Rendering.Universal;

public class EquipedUpgrade : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] Bullet bullet;
    [SerializeField] Level level;
    [SerializeField] EnemyBullet enemyBullet;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject god;
    [SerializeField] GameObject buffText;
    [SerializeField] GameObject nerfText;
    [SerializeField] UnityEngine.Rendering.Universal.Light2D light2d;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    [SerializeField] [Range(0f, 1f)] float stealHpChance = 1f;

    public EquipedUpgradeSO _euSO;

    private void Awake()
    {
        _euSO.OnAfterDeserialize();
        god.SetActive(false);
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
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 100; i++)
        {
            cinemachine.m_Lens.OrthographicSize += 0.014f;
            light2d.pointLightOuterRadius += 0.025f;
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (_euSO.upgrade01 == true)
        {
            enemyBullet.isSlow = true;
        }

        if (_euSO.upgrade02 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade02 = false;
            _euSO.upgraded02 = true;
        }

        if (_euSO.upgrade03 == true)
        {
            playerAttack.cooltime -= 0.025f;
            _euSO.upgrade03 = false;
            _euSO.upgraded03 = true;
        }

        if (_euSO.upgrade04 == true)
        {
            playerAttack.isPenetrated = true;
            playerAttack.isNerfedDamage = true;
        }

        if (_euSO.upgrade05 == true)
        {
            level.levelToExperience -= 120;
            _euSO.upgrade05 = false;
            _euSO.upgraded05 = true;
        }


        if (_euSO.upgrade07 == true)
        {
            playerController.speed += 0.35f;
            _euSO.upgrade07 = false;
            _euSO.upgraded07 = true;
        }

        if (_euSO.upgrade08 == true)
        {
            playerAttack.reloadtime -= 0.1f;
            _euSO.upgrade08 = false;
            _euSO.upgraded08 = true;
        }

        if (_euSO.upgrade09 == true)
        {
            playerController.maxHp += 5f;
            _euSO.upgrade09 = false;
            _euSO.upgraded09 = true;
        }

        if (_euSO.upgrade10 == true)
        {
            arrow.SetActive(true);
        }

        if (_euSO.upgrade11 == true)
        {
            god.SetActive(true);
            Invoke("GoDestroy", 3f);
            god.transform.position = playerController.transform.position;
            _euSO.upgrade11 = false;
            _euSO.upgraded11 = true;
        }

        if (_euSO.upgrade12)
        {
            if (playerController.currentHp <= 10)
            {
                playerController.currentHp += 70;
                _euSO.upgrade12 = false;
                _euSO.upgraded12 = true;
            }
        }

        if (_euSO.upgrade13 == true)
        {
            StartCoroutine(CameraZoom());
            _euSO.upgrade13 = false;
            _euSO.upgraded13 = true;
        }

        if (_euSO.upgrade14 == true)
        {
            if (Random.value < 0.5f)
            {
                playerController.maxHp += 20;
                playerAttack.BulletDamage += 10;
                GameObject Text1 = Instantiate(buffText);
                Text1.transform.position = transform.position;
                _euSO.upgrade14 = false;
                _euSO.upgraded14 = true;
            }
            else
            {
                playerController.maxHp -= 15;
                playerController.currentHp -= 15;
                playerAttack.BulletDamage -= 5;
                GameObject Text = Instantiate(nerfText);
                Text.transform.position = transform.position;
                _euSO.upgrade14 = false;
                _euSO.upgraded14 = true;
            }
        }

        if (_euSO.upgrade15 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade15 = false;
            _euSO.upgraded15 = true;
        }
        if (_euSO.upgrade16 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade16 = false;
            _euSO.upgraded16 = true;
        }
        if (_euSO.upgrade17 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade17 = false;
            _euSO.upgraded17 = true;
        }
        if (_euSO.upgrade18 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade18 = false;
            _euSO.upgraded18 = true;
        }
        if (_euSO.upgrade19 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade19 = false;
            _euSO.upgraded19 = true;
        }
        if (_euSO.upgrade20 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade20 = false;
            _euSO.upgraded20 = true;
        }
        if (_euSO.upgrade21 == true)
        {
            playerAttack.BulletDamage += 5f;
            _euSO.upgrade21 = false;
            _euSO.upgraded21 = true;
        }
        if (_euSO.upgrade22 == true)
        {
            playerAttack.BulletDamage += 10f;
            _euSO.upgrade22 = false;
            _euSO.upgraded22 = true;
        }
        if (_euSO.upgrade23 == true)
        {
            playerAttack.BulletDamage += 15f;
            _euSO.upgrade23 = false;
            _euSO.upgraded23 = true;
        }
        if (_euSO.upgrade24 == true)
        {
            playerAttack.cooltime -= 0.025f;
            _euSO.upgrade24 = false;
            _euSO.upgraded24 = true;
        }
        if (_euSO.upgrade25 == true)
        {
            playerAttack.cooltime -= 0.025f;
            _euSO.upgrade25 = false;
            _euSO.upgraded25 = true;
        }
        if (_euSO.upgrade26 == true)
        {
            playerAttack.cooltime -= 0.025f;
            _euSO.upgrade26 = false;
            _euSO.upgraded26 = true;
        }
        if (_euSO.upgrade27 == true)
        {
            playerAttack.cooltime -= 0.03f;
            _euSO.upgrade27 = false;
            _euSO.upgraded27 = true;
        }
        if (_euSO.upgrade28 == true)
        {
            playerController.speed += 0.25f;
            _euSO.upgrade28 = false;
            _euSO.upgraded28 = true;
        }
        if (_euSO.upgrade29 == true)
        {
            playerController.speed += 0.25f;
            _euSO.upgrade29 = false;
            _euSO.upgraded29 = true;
        }
        if (_euSO.upgrade30 == true)
        {
            playerController.speed += 0.25f;
            _euSO.upgrade30 = false;
            _euSO.upgraded30 = true;
        }
        if (_euSO.upgrade31 == true)
        {
            playerController.speed += 0.4f;
            _euSO.upgrade31 = false;
            _euSO.upgraded31 = true;
        }
        if (_euSO.upgrade32 == true)
        {
            playerAttack.reloadtime -= 0.05f;
            _euSO.upgrade32 = false;
            _euSO.upgraded32 = true;
        }
        if (_euSO.upgrade33 == true)
        {
            playerAttack.reloadtime -= 0.05f;
            _euSO.upgrade33 = false;
            _euSO.upgraded33 = true;
        }
        if (_euSO.upgrade34 == true)
        {
            playerAttack.reloadtime -= 0.05f;
            _euSO.upgrade34 = false;
            _euSO.upgraded34 = true;
        }
        if (_euSO.upgrade35 == true)
        {
            playerAttack.reloadtime -= 0.15f;
            _euSO.upgrade35 = false;
            _euSO.upgraded35 = true;
        }
        if (_euSO.upgrade36 == true)
        {
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>().radius += 1;
            _euSO.upgrade36 = false;
            _euSO.upgraded36 = true;
        }
        if (_euSO.upgrade37 == true)
        {
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>().radius += 1;
            _euSO.upgrade37 = false;
            _euSO.upgraded37 = true;
        }
        if (_euSO.upgrade38 == true)
        {
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>().radius += 1;
            _euSO.upgrade38 = false;
            _euSO.upgraded38 = true;
        }
        if (_euSO.upgrade39 == true)
        {
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>().radius += 1;
            _euSO.upgrade39 = false;
            _euSO.upgraded39 = true;
        }
        if (_euSO.upgrade40 == true)
        {
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>().radius += 2;
            _euSO.upgrade40 = false;
            _euSO.upgraded40 = true;
        }
        if (_euSO.upgrade41 == true)
        {
            playerController.maxHp += 5f;
            _euSO.upgrade41 = false;
            _euSO.upgraded41 = true;
        }
        if (_euSO.upgrade42 == true)
        {
            playerController.maxHp += 5f;
            _euSO.upgrade42 = false;
            _euSO.upgraded42 = true;
        }
        if (_euSO.upgrade43 == true)
        {
            playerController.maxHp += 5f;
            _euSO.upgrade43 = false;
            _euSO.upgraded43 = true;
        }
        if (_euSO.upgrade44 == true)
        {
            playerController.maxHp += 15f;
            _euSO.upgrade44 = false;
            _euSO.upgraded44 = true;
        }
    }

    private void GoDestroy()
    {
        Destroy(god);
    }
}
