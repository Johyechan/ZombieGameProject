using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShakeAnimation : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Shake");     
        }
    }
}
