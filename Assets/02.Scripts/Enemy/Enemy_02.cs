using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02 : Enemy
{
    [SerializeField] public float enemy02_damage = 1f;
    [SerializeField] public float enemy02_speed = 2f;
    [SerializeField] int enemy02_experience_reward = 500;
    [SerializeField] private float enemy02_currentHp = 55f;
    [SerializeField] private float enemy02_maxHp = 55f;

    public float atkDistance = 6.5f;
    public float distance;

    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform atkPos;
    public float cooltime = 1f;
    public float currenttime;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        enemy02_currentHp = enemy02_maxHp;
    }


    public override void EnemyMove()
    {      
        base.EnemyMove();
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigid.velocity = direction * enemy02_speed;
        if (Vector2.Distance(gameObject.transform.position, targetGameobject.transform.position) < atkDistance)
        {
            if (currenttime <= 0)
            {
                GameObject bulletcopy = Instantiate(bullet, atkPos.transform.position, atkPos.transform.rotation);
                currenttime = cooltime;
            }
            anim.SetBool("Attack", true);
            enemy02_speed = 0;
        }
        else
        {
            anim.SetBool("Attack", false);
            enemy02_speed = 3f;
        }
        currenttime -= Time.deltaTime;
    }

    public override void Attack()
    {
        base.Attack();
        GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(enemy02_damage);
    }

    public override void EnemyTakeDamage(float damage)
    {
        enemy02_currentHp -= damage;

        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = damage;

        if (enemy02_currentHp <= 0)
        {
            coll2d.isTrigger = true;
            GameObject.Find("Player").GetComponent<Level>().AddExperience(enemy02_experience_reward);
            enemy02_speed = 0;
            anim.SetTrigger("Die");
            Invoke("Destroy", 0.4f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
