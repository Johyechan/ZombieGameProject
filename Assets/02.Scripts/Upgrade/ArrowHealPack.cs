using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowHealPack : MonoBehaviour
{
    [SerializeField] FoodSpawner food;
    [SerializeField] HealFood target;
    [SerializeField] GameObject upButton;
    [SerializeField] GameObject downButton;
    Animator anim;
    private float speed = 500;
    private float axis = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        upButton.SetActive(false);
        downButton.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        anim.SetTrigger("Up");
        Invoke("SetActiveDown", 0.95f);
    }

    private void Update()
    {
        Update_LookRotation();       
    }

    void SetActiveDown()
    {
        downButton.SetActive(true);
    }
    void SetActiveUp()
    {
        upButton.SetActive(true);
    }

    public void OnClickUp()
    {
        anim.SetTrigger("Up");
        Invoke("SetActiveDown", 0.95f);
        upButton.SetActive(false);
    }
    public void OnClickDown()
    {
        anim.SetTrigger("Down");
        Invoke("SetActiveUp", 0.95f);
        downButton.SetActive(false);
    }

    private void Update_LookRotation()
    {
        Vector3 myPos = transform.position;
        target = FindObjectOfType<HealFood>();
        Vector3 targetPos = target.transform.position;
        if (targetPos == null) return;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        Vector3 quaternionToTarget = Quaternion.Euler(0, 0, axis) * vectorToTarget;

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: quaternionToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
