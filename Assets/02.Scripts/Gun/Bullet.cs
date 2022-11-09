using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public BoxCollider2D coll;

    [SerializeField] private float bulletDamage;
    public float BulletDamage { get => bulletDamage; set => bulletDamage = value; }

    void Start()
    {
        Invoke("DestroyBullet", 2f);
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {       
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.EnemyTakeDamage(BulletDamage);
        }
    }
}
