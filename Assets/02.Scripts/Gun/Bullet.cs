using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Animator anim;

    [SerializeField] private float bulletDamage;
    public float BulletDamage { get => bulletDamage; set => bulletDamage = value; }

    void Start()
    {
        //bulletDamage = 10;
        Invoke("DestroyBullet", 1.5f);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //bulletDmg = Random.Range(BulletDamage - 1.0f, BulletDamage + 3.0f);
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
            enemy.EnemyTakeDamage(bulletDamage);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
