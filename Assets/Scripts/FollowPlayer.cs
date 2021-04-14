using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Transform playerTransform;
    Vector3 distance;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distance = transform.position - playerTransform.position;

    }

    void LateUpdate()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = playerTransform.position + distance;
        }
       
    }

    private void Update()
    {
        if (playerTransform==null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
