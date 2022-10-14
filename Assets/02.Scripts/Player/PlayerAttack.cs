using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    public GameObject gunModel;

    AudioSource audio1;
    [SerializeField] AudioClip[] shootSound;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (curtime <= 0)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
                audio1.clip = shootSound[0];
                audio1.PlayOneShot(shootSound[0]);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
