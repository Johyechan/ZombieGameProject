using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] int exAmount = 500;
    private void PickUpGems()
    {
        GameObject.Find("Player").GetComponent<Level>().AddExperience(exAmount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            PickUpGems();
        }        
    }
}
