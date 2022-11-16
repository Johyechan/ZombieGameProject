using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5;
    public bool isSlow = false;
    float bulletDmg;
    [SerializeField] private float BulletDamage = 15;

    void Start()
    {
        bulletSpeed = 5f;
        Invoke("DestroyBullet", 5f);
    }

    void Update()
    {
        if (isSlow)
        {
            bulletSpeed = 4f;
        }
        else
        {
            bulletSpeed = 5f;
        }
        bulletDmg = Random.Range(BulletDamage - 1.0f, BulletDamage + 4.0f);
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(bulletDmg);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
