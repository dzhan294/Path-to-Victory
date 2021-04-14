using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowAttack : MonoBehaviour
{
    Transform enemyTransform;

    void Start()
    {
        if (GameObject.Find("Enemy"))
        {
            enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        }          
    }


    void Update()
    {
        transform.LookAt(enemyTransform);
        transform.Translate(Vector3.forward * 30 * Time.deltaTime);

        Destroy(this.gameObject, 3.0f);

    }

   
}
