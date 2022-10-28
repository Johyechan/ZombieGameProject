using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer rend;
    public Rigidbody2D rigid;
    public Animator anim;
    public CapsuleCollider2D coll2d;

    public Transform targetDestination;
    public GameObject targetGameobject;

    public GameObject hudDamageText;
    public Transform hudPos;
    
    float speed; //이동속도
    [Range(0f, 3f)] float contactDistance = 1f;
    private float damage = 1;
    private float currentHp = 50f;
    private float maxHp = 50f;
    int experience_reward = 400;


    private void Update()
    {
        if (targetGameobject.transform.position.x < transform.position.x)
        {
            rend.flipX = true;
        }
        else if (targetGameobject.transform.position.x > transform.position.x)
        {
            rend.flipX = false;
        }
    }

    public void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigid.velocity = direction * speed;
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            StartCoroutine(ColorEffect());
        }
    } 

    private IEnumerator ColorEffect() //피격 시 빨간색으로 변함
    {
        rend.DOColor(Color.red, 0.15f);
        yield return new WaitForSeconds(0.1f);
        rend.DOColor(Color.white, 0.15f);
    }

    public virtual void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(damage);
    }

    public virtual void EnemyTakeDamage(float damage)
    {
        currentHp -= damage;

        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = damage;

        if (currentHp <= 0)
        {
            coll2d.isTrigger = true;
            GameObject.Find("Player").GetComponent<Level>().AddExperience(experience_reward);
            speed = 0;
            anim.SetTrigger("Die");
            Invoke("Destroy", 0.35f);          
        }
    }
}
