using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    SpriteRenderer rend;
    Animator anim;
    AudioSource audio1;
    Rigidbody2D rigid;
    Vector3 movementVector;

    [SerializeField] HPBar hpBar;

    [Header ("Position")]
    public Vector3 screenPosition;
    public Vector3 worldPos;
    public Vector3 targetPos;
    float posValue = 0f;

    [Header ("Audio")]
    [SerializeField] public AudioClip[] CD;

    [Header("Stat")]
    [SerializeField] float maxHp = 100;
    [SerializeField] float currentHp = 100;
    [SerializeField] public float speed = 5.0f;
    public GameObject GameOverPanel;

    //private Vector3 moveDirecion = Vector3.zero;

    private void Start()
    {
        currentHp = maxHp;
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio1 = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        audio1.volume = 0;
    }

    private void Update()
    {
        //움직임
        movementVector = new Vector3().normalized;
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        Vector3 direction = (movementVector).normalized;
        rigid.velocity = direction * speed;

        //애니메이션, 사운드
        if (movementVector.x == 0 && movementVector.y == 0)
        {
            anim.SetBool("isRun", false);
            audio1.clip = CD[0];
            audio1.Play();
        }
        else
        {
            anim.SetBool("isRun", true);
            audio1.volume = 0.25f;
        }

        //마우스 방향 따라 좌우반전
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;
        worldPos = Camera.main.ScreenToWorldPoint(screenPosition);
        posValue = transform.position.x;
        
        if (worldPos.x < posValue) 
        {
            rend.flipX = true;
        }
        else if (worldPos.x > posValue)
        {
            rend.flipX = false;
        }
        
        

        //체력 오버되지 않게 관리
        if(maxHp <= currentHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void TakeDamage(float damage)
    {      
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Debug.Log("GAME OVER");
            currentHp = 100;
            currentHp++;
            Pause();
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(float heal)
    {
        currentHp += heal;
        hpBar.SetState(currentHp, maxHp);
    }
    public void Pause()
    {
        GameOverPanel.SetActive(true);
       
        Time.timeScale = 0f;
       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.Find("CameraShake").GetComponent<CameraShake>().HitShake();
            StartCoroutine(ColorEffect());
        }
    }

    private IEnumerator ColorEffect() //피격 시 빨간색으로 변함
    {
        rend.DOColor(Color.red, 0.1f);
        yield return new WaitForSeconds(0.1f);
        rend.DOColor(Color.white, 0.15f);
    }
}
