using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerMove : MonoBehaviour
{
    Transform m_transform, m_camera;
    Animator animator;
    private Vector3 moveDirec=Vector3.zero;

    private Camera _camera;
    public float moveSpeed = 5;

    void Start()
    {
        m_transform = this.transform;
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        animator = this.GetComponent<Animator>();

        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Camera>();

    }


    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        if (((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))) 
            && !info.IsName("attack") && !info.IsName("hit") && !info.IsName("Skill"))
        {
            //  walkAudio.enabled = true;
            animator.SetBool("isMove", true);

            if (Input.GetKey(KeyCode.W))
            {
                //The moving direction of the character is determined according to the orientation of the main camera, 
                //the same below
                transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 180f, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 270f, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 90f, 0);
            }
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        else
        {
            //  walkAudio.enabled = false;
            animator.SetBool("isMove", false);
        }

    }
}
