using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField] int exAmount = 500;
    public Transform playerTransform;
    public float moveSpeed = 13f;
    public bool isCanMove = false;

    CoinMove coinMove;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMove = gameObject.GetComponent<CoinMove>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            isCanMove = true;        
        }
        else
        {
            isCanMove = false;
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBubble")
        {
            GameObject.Find("Player").GetComponent<Level>().AddExperience(exAmount);
            Destroy(gameObject);
        }
    }
}
