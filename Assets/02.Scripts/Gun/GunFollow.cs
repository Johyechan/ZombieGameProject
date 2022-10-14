using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPos;
    public Vector3 targetPos;
    float posValue = 0f;

    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //rend.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        //마우스 방향 따라 좌우반전
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;
        worldPos = Camera.main.ScreenToWorldPoint(screenPosition);
        targetPos = gameObject.transform.position;
        posValue = targetPos.x;

        if (worldPos.x < posValue)
        {
            gameObject.transform.localScale = new Vector3(-1, -1, 1);
            rend.flipX = true;
        }
        else if (worldPos.x > posValue)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            rend.flipX = false;
        }
    }
}
