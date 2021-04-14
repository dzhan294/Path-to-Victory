using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDemage : MonoBehaviour
{
    private Transform bloodPoint;
    public GameObject bloodEffect;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            bloodPoint = GameObject.FindGameObjectWithTag("Enemy").
                transform.Find("bloodPoint").transform;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {   
            if (Enemy._instance.curren_Hp > 0)
            {
                bloodPoint = other.transform.Find("bloodPoint").transform;
                GameObject.Instantiate(bloodEffect, bloodPoint.position, Quaternion.identity);
                PlayerAttack._instance.bullectToBodyAudio.Play();
                Enemy._instance.anima.Play("hit back");
                Enemy._instance.curren_Hp -= PlayerInfo._instance.attack;
                PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
                //print("1");
             
            }
            if (PlayerPrefs.GetInt("roleIndex")==0)
            {
                Destroy(this.gameObject);
            }
           
        }
}
}
