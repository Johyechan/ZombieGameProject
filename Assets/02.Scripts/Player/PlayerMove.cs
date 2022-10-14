using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 movementVector;

    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        movementVector = new Vector3().normalized;
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        Vector3 direction = (movementVector).normalized;
        rigid.velocity = direction * speed;
    }

}
