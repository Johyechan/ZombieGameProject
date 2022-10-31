using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5;
    float bulletDmg;
    [SerializeField] private float BulletDamage = 15;

    void Start()
    {
        Invoke("DestroyBullet", 3.5f);
    }

    void Update()
    {
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
