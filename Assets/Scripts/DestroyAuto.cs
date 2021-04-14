using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAuto : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,2.0f); 
    }
}
