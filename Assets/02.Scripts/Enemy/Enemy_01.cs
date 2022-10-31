using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_01 : Enemy
{
    [SerializeField] float enemy01_damage = 1f;
    [SerializeField] float enemy01_speed = 3f;
    [SerializeField] int enemy01_experience_reward = 400;
    [SerializeField] private float enemy01_currentHp = 40f;
    [SerializeField] private float enemy01_maxHp = 40f;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        enemy01_currentHp = enemy01_maxHp;
    }

    public override void EnemyMove()
    {
        base.EnemyMove();
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigid.velocity = direction * enemy01_speed;
    }

    public override void Attack()
    {
        base.Attack();
        GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(enemy01_damage);
    }

    public override void EnemyTakeDamage(float damage)
    {
        enemy01_currentHp -= damage;

        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = damage;

        if (enemy01_currentHp <= 0)
        {
            coll2d.isTrigger = true;
            GameObject.Find("Player").GetComponent<Level>().AddExperience(enemy01_experience_reward);
            enemy01_speed = 0;
            anim.SetTrigger("Die");
            Invoke("Destroy", 0.35f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
