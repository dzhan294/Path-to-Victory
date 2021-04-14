using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack _instance;

    public Animator animator;
    public GameObject bloodEffectPrafab; //Bleeding effect
    public GameObject arrowPrefab;

    public Transform arrowSpawnPos;

    private bool isMoving = false;

    private Vector3 targetPos = Vector3.zero; 

    public AudioSource attackAudio; //Attack sound
    public AudioSource bullectToBodyAudio;
    public AudioSource playerHitAudio; //Player injured sound

    public float distance = 0;

    public bool isShoot = false;

    //Enemy Hp Slider
    public GameObject enemyHpBarGo;
    private Slider enemyHpSlider;
    private Text enemyHpNameText;

    public GameObject skillPrefab;

    private Animator gameOverAnimator;

    public bool isGameOver = false;
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //Cursor.visible = false;
        animator = GetComponent<Animator>();
        attackAudio = GetComponent<AudioSource>();

        enemyHpBarGo = GameObject.Find("EnemyHpBar");
        enemyHpSlider = GameObject.Find("EnemyHpBar").GetComponent<Slider>();
        enemyHpNameText = GameObject.Find("EnemyHpBar/nameText").GetComponent<Text>();

        gameOverAnimator = GameObject.Find("DefeatUI").GetComponent<Animator>();
    }

    void Update()
    {
        enemyHpSlider.value = Enemy._instance.curren_Hp / Enemy._instance.total_Hp;

        AnimatorStateInfo info = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (Input.GetMouseButtonDown(0) && !info.IsName("run") && isGameOver==false &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform);
            }       
            animator.Play("attack");

        }
        if (Input.GetMouseButtonDown(1) && !info.IsName("run") && PlayerInfo._instance.currenMp>= 55 
            && isGameOver == false)
        {
            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform);
                PlayerInfo._instance.currenMp -= 55;
            }
            animator.Play("Skill");
        }

        if (PlayerInfo._instance.currenHp<0)
        {
            playerDie();
        }

    }
    
    public void SkillDemage()
    {
        //If the current character is archer
        if (PlayerPrefs.GetInt("roleIndex") == 0)
        {
            GameObject.Instantiate(skillPrefab, transform.position + new Vector3(0, 0, 0.1f), transform.rotation);

        }
        if (PlayerPrefs.GetInt("roleIndex") == 1)
        {
            GameObject.Instantiate(skillPrefab, transform.position + new Vector3(0, 0, 0.5f), transform.rotation);

        }
        if (PlayerPrefs.GetInt("roleIndex") == 2)
        {
            Vector3 enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
            GameObject.Instantiate(skillPrefab, enemyPos, transform.rotation);

        }
        if (PlayerPrefs.GetInt("roleIndex") == 3)
        {
            Vector3 enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
            GameObject.Instantiate(skillPrefab, enemyPos, transform.rotation);

        }
        if (PlayerPrefs.GetInt("roleIndex") == 4)
        {
            Vector3 enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
            GameObject.Instantiate(skillPrefab, enemyPos, transform.rotation);

        }
        if (PlayerPrefs.GetInt("roleIndex") == 5)
        {
            GameObject.Instantiate(skillPrefab, 
                transform.position + new Vector3(0, 0, 0.5f), 
                transform.rotation);

        }
    }


    public void NormalAttack()
    {
        attackAudio.Play();

        //If the current character is archer
        if (PlayerPrefs.GetInt("roleIndex") == 0)
        {
            GameObject arrowGo = GameObject.Instantiate(arrowPrefab,
         arrowSpawnPos.position,
        arrowSpawnPos.rotation);
        }
        
    }

    public void playerDie()
    {
        animator.Play("Die");
        gameOverAnimator.enabled = true;
        isGameOver = true;
    }

    //Restart the game
    public void OnRetryClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

}
