using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private Button btn_continue;
    private Button btn_playAgain;
    private Button btn_main;
    int sceneIndex = 0;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        btn_continue = transform.Find("btn_continueGame").GetComponent<Button>();
        btn_continue.onClick.AddListener(OnBtnContinueClick);

        btn_playAgain = transform.Find("btn_playAgain").GetComponent<Button>();
        btn_playAgain.onClick.AddListener(OnBtnPlayAgainClick);

        btn_main = transform.Find("btn_main").GetComponent<Button>();
        btn_main.onClick.AddListener(OnBtnMainClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.localScale = Vector3.one;
            Time.timeScale = 0;
        }
    }

    private void OnBtnContinueClick()
    {
        transform.localScale = Vector3.zero;
        Time.timeScale = 1;
    }

    private void OnBtnPlayAgainClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(sceneIndex);   
    }

    private void OnBtnMainClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
