using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    public Transform pos;
    public float cooltime;
    private float curtime;
    public GameObject gunModel;
    public GameObject PoolBullet;
    public GameObject[] PoolBullets = new GameObject[30];
    private int bulletCount = 0;
    public bool reloading;
    private float reloadtime = 1f;
    private float chargingtime;
    private int bulletTextCount = 30;

    [SerializeField] TMPro.TextMeshProUGUI bulletText;
    AudioSource audio1;
    [SerializeField] AudioClip[] shootSound;


    void Start()
    {
        reloading = false;
        audio1 = GetComponent<AudioSource>();
        for (int i = 0; i < PoolBullets.Length; i++)
        {
            PoolBullets[i] = Instantiate(PoolBullet);
            PoolBullets[i].SetActive(false);
        }
    }

    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.R))
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
            chargingtime = 0;
        }
    }

    public void Reload()
    {
        bulletCount = 0;
        bulletTextCount = 30;
        reloading = true;
        audio1.clip = shootSound[1];
        audio1.PlayOneShot(shootSound[1]);
    }
    public void bulletpool()
    {
        PoolBullets[bulletCount].SetActive(true);
        PoolBullets[bulletCount].transform.position = pos.position;
        PoolBullets[bulletCount].transform.rotation = transform.rotation;
        bulletCount++;
        bulletTextCount--;
        audio1.clip = shootSound[0];
        audio1.PlayOneShot(shootSound[0]);
    }
}
