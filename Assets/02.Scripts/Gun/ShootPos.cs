using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPos : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPos;
    public Vector3 targetPos;
    float posValue = 0f;
    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

    }
}