using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn _instance;
    public GameObject enemyPrefab;
    public Text enemyNumText;

    public int enemyNum = 6;
    public Animator gameSuccessAnimator;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level-01":
                enemyNum = 6;
                break;
            case "Level-02":
                enemyNum = 10;
                break;
            case "Level-03":
                enemyNum = 15;
                break;
            case "Level-04":
                enemyNum = 20;
                break;
            case "Level-05":
                enemyNum = 22;
                break;
            case "Level-06":
                enemyNum = 30;
                break;
            default:
                break;
        }

    }


    void Update()
    {
        enemyNumText.text = "Remaining enemies： " + enemyNum;
        if (!GameObject.FindGameObjectWithTag("Enemy") && enemyNum>0)
        {
            GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
        if (enemyNum == 0)
        {
            gameSuccessAnimator.enabled = true;
            
        }
    }
}
