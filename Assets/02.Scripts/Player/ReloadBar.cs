using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    [SerializeField] GameObject firstPos;
    [SerializeField] GameObject target;
    [SerializeField] PlayerAttack playerAttack;
    public bool canReload;

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(firstPos.transform.position.x, firstPos.transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        if (canReload)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 0.03f);         
        }
        else if (canReload == false)
        {
            gameObject.transform.position = new Vector3(firstPos.transform.position.x, firstPos.transform.position.y, 0);
        }
    }
}
