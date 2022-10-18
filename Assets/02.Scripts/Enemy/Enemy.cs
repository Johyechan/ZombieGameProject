using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    SpriteRenderer rend;
    Rigidbody2D rigid;
    Animator anim;
    CircleCollider2D coll2d;

    Transform targetDestination;
    GameObject targetGameobject;

    public GameObject hudDamageText;
    public Transform hudPos;
    
    [SerializeField] float speed; //이동속도
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;
    [SerializeField] private float damage = 1;
    [SerializeField] private float currentHp = 50f;
    [SerializeField] private float maxHp = 50f;
    [SerializeField] int experience_reward = 400;

    bool follow = true;
    bool canMove = true;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        currentHp = maxHp;
    }

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

    private void FixedUpdate()
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

    private void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(damage);
    }

    public void EnemyTakeDamage(float damage)
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

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
