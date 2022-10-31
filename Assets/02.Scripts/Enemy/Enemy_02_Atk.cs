using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_Atk : MonoBehaviour
{
    public GameObject target;
    private void FixedUpdate()
    {
        target = GameObject.Find("Player");
        Vector3 len = target.transform.position - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
