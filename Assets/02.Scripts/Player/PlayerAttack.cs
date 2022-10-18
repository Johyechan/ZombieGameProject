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
    public int bulletCount = 0;
    private int bulletTextCount = 30;

    [SerializeField] TMPro.TextMeshProUGUI bulletText;

    AudioSource audio1;
    [SerializeField] AudioClip[] shootSound;

    void Start()
    {
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
        Reload();
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (curtime <= 0)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {
                PoolBullets[bulletCount].SetActive(true);
                PoolBullets[bulletCount].transform.position = pos.position;
                PoolBullets[bulletCount].transform.rotation = transform.rotation;
                bulletCount++;
                bulletTextCount--;
                audio1.clip = shootSound[0];
                audio1.PlayOneShot(shootSound[0]);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }

    public void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            for(int i = 0; i < PoolBullets.Length; i++)
            {
                bulletCount = 0;
                bulletTextCount = 30;
            }
        }
    }
}
