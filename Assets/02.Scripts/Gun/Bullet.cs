using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public float speed;
    float bulletDmg;
    Animator anim;
    [SerializeField] private float BulletDamage = 10;

    void Start()
    {
        Invoke("DestroyBullet", 1f);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bulletDmg = Random.Range(BulletDamage - 1.0f, BulletDamage + 4.0f);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.EnemyTakeDamage(bulletDmg);
            gameObject.SetActive(false);
        }
    }
}
