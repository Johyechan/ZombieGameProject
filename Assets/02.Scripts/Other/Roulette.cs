using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private float random;
    public float speed;
    public float spinTime = 0f;
    private bool one = true;
    private bool two = true;
    private bool three = true;
    void Start()
    {
        random = Random.Range(8, 16);
        speed = random;
    }
    void Update()
    {
        spinTime += Time.deltaTime;
        if(spinTime < 6 && spinTime > 3 && one)
        {
            speed -= 2;
            one = false;
        }
        else if(spinTime < 9 && spinTime > 6 && two)
        {
            speed -= 5;
            two = false;
        }
        else if(spinTime > 9 && three)
        {
            speed = 0;
            three = false;
        }
        transform.Rotate(0, 0, -speed, 0);
    }
}
