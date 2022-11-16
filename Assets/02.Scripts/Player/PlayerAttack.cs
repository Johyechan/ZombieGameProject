using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float bulletDamage;
    public float BulletDamage { get => bulletDamage; set => bulletDamage = value; }
    public float upgradeDamage;
    public float nerfedDamage;

    public Transform pos;
    public float cooltime;
    private float curtime;
    public GameObject gunModel;
    public GameObject PoolBullet;
    public GameObject[] PoolBullets = new GameObject[30];
    private int bulletCount = 0;
    public bool reloading;
    public float reloadtime = 1f;
    public float chargingtime;
    public int bulletTextCount = 30;

    public bool isupgradedDamage = false;
    public bool isNerfedDamage = false;
    public bool isPenetrated = false;

    [SerializeField] TMPro.TextMeshProUGUI bulletText;
    AudioSource audio1;
    [SerializeField] AudioClip[] shootSound;
    [SerializeField] ReloadBar reloadBar;
    [SerializeField] GameObject reloadbar;
    [SerializeField] GameObject reloadbarBase;

    void Start()
    {
        reloading = false;
     
        reloadbar.SetActive(false);
        reloadbarBase.SetActive(false);
        audio1 = GetComponent<AudioSource>();
        for (int i = 0; i < PoolBullets.Length; i++)
        {
            PoolBullets[i] = Instantiate(PoolBullet);
            PoolBullets[i].SetActive(false);
        }
    }

    void Update()
    {
        upgradeDamage = bulletDamage * 1.3f;
        nerfedDamage = bulletDamage * 0.9f;

        bulletText.text = $"{bulletTextCount}/" + PoolBullets.Length.ToString();
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        if (curtime <= 0)
        {
            if (!reloading)
            {
                if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
                {
                    bulletpool();
                }
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && bulletTextCount < 30)
        {
            Reload();
        }
        if (reloading)
        {
            chargingtime += Time.deltaTime;
        }
        if(chargingtime >= reloadtime)
        {
            reloading = false;
            reloadBar.canReload = false;
            
            chargingtime = 0;
            reloadbarBase.SetActive(false);
            reloadbar.SetActive(false);
        }
    }

    public void Reload()
    {
        bulletCount = 0;
        bulletTextCount = 30;
        reloadbar.SetActive(true);
        reloadbarBase.SetActive(true);
        reloading = true;
        audio1.clip = shootSound[1];
        audio1.PlayOneShot(shootSound[1]);
        reloadBar.canReload = true;
    }
    public void bulletpool()
    {
        PoolBullets[bulletCount].SetActive(true);
        PoolBullets[bulletCount].transform.position = pos.position;
        PoolBullets[bulletCount].transform.rotation = transform.rotation;

        if (isNerfedDamage == false)
        {
            PoolBullets[bulletCount].GetComponent<Bullet>().BulletDamage = bulletDamage;
        }
        else if (isNerfedDamage)
            PoolBullets[bulletCount].GetComponent<Bullet>().BulletDamage = nerfedDamage;

        if (isPenetrated == false)
        {
            PoolBullets[bulletCount].GetComponent<Bullet>().coll.isTrigger = false;
        }
        else if (isPenetrated)
            PoolBullets[bulletCount].GetComponent<Bullet>().coll.isTrigger = true;

        bulletCount++;
        bulletTextCount--;
        audio1.clip = shootSound[0];
        audio1.PlayOneShot(shootSound[0]);
    }
}
