using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFood : MonoBehaviour
{
    [SerializeField] private float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Heal");
            GameObject.Find("Player").GetComponent<PlayerController>().Heal(heal);
            gameObject.SetActive(false); 
        }
    }
}
