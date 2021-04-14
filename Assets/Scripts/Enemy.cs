using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy _instance;

    public float curren_Hp = 600;
    public float total_Hp = 600;
    public int enemyAttack = 310; 

    public Animation anima;

    public bool isDie = false;

    Transform playerTransform;

    float distance = 0;

    bool isFind = false;

    public float attackRate = 1.0f;

    void Start()
    {
        _instance = this;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anima = GetComponent<Animation>();
       
    }


    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(transform.position, playerTransform.position);        

        if (curren_Hp <= 0)
        {
            curren_Hp = 0;
            anima.Play("die hard");
            isDie = true;
        }
        transform.LookAt(playerTransform);
        if (distance < 2.3f && curren_Hp > 0 && PlayerAttack._instance.isGameOver == false
            && PlayerInfo._instance.currenHp > 0)
        {       
            attackRate -= Time.deltaTime;
            if (attackRate <= 0)
            {
                anima.Play("spear attack");
            }

        }
        else if (distance > 2.3f && curren_Hp > 0 && PlayerAttack._instance.isGameOver == false
             && PlayerInfo._instance.currenHp > 0)
        {
            attackRate = 1.0f;
            transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);
            anima.Play("Run");
        }

        if (PlayerAttack._instance.isGameOver)
        {
            anima.Play("idle");
        }
    }

    //Particle collision detection
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag=="ArcherSkill" && curren_Hp>0)
        {
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
        if (other.tag == "KnightSkill" && curren_Hp > 0)
        {
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
        if (other.tag == "WizardSkill" && curren_Hp > 0)
        {
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
        if (other.tag == "GuardSkill" && curren_Hp > 0)
        {
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
        if (other.tag == "AssasinSkill" && curren_Hp > 0)
        {
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
        if (other.tag == "WarriorSkill" && curren_Hp > 0)
        {
         //   print("122");
            PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.one;
            anima.Play("hit back");
            Enemy._instance.curren_Hp -= PlayerInfo._instance.skillAttack;
        }
    }

    public void HitToIdle()
    {
        anima.Play("idle");
    }
    public void Die()
    {
        EnemySpawn._instance.enemyNum--;
        PlayerAttack._instance.enemyHpBarGo.transform.localScale = Vector3.zero;
        Destroy(this.gameObject);
    }

    //Cause damage to players
    public void demageToPlayer()
    {
        attackRate = 1.0f;
        PlayerInfo._instance.currenHp -= enemyAttack;
        PlayerAttack._instance.animator.Play("hit");
        PlayerAttack._instance.playerHitAudio.Play();

    }
}
