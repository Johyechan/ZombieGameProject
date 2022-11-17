using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coin coin;

    private void Start()
    {
        coin = gameObject.GetComponent<Coin>();
    }

    private void Update()
    {
        if (coin.isCanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, coin.playerTransform.position,
                coin.moveSpeed * Time.deltaTime);
        }
    }
}
